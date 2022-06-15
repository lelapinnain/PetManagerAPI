using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models;
using PetManager.Models.NonQueries;
using PetManager.Utilities;

namespace PetManager.Controllers.PostControllers
{
    //[Authorize]
    [Route("PetManager/SubmitInvoice")]
    public class SubmitInvoiceController : AbstractControllerPost<SubmitInvoiceDTO>
    {
        private readonly IViewRenderService viewRenderService;

        public SubmitInvoiceController(IViewRenderService _viewRenderService)
        {
            viewRenderService = _viewRenderService;
        }


        public override async Task< IActionResult> Post([FromBody] SubmitInvoiceDTO input)
        {
            CoreDbContext db = new CoreDbContext();
            var dbContextTransaction = db.Database.BeginTransaction();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }

                CustomerInsertQuery customerInsertQuery = new CustomerInsertQuery(db, input.Customer);
               await customerInsertQuery.RunQuery();

                InvoiceInsertQuery invoiceInsertQuery = new InvoiceInsertQuery(db, input.Payment, customerInsertQuery.GetResult(), input.PetId);
               await invoiceInsertQuery.RunQuery();

                PaymentInsertQuery paymentInsertQuery = new PaymentInsertQuery(db, invoiceInsertQuery.GetResult(), input.Payment.PaymentMethod, input.Payment.DepositAmount);
                await paymentInsertQuery.RunQuery();

                if (paymentInsertQuery.GetResult() == "ok")
                {
                    //return Ok(petInfoInsert.GetResult());
                    dbContextTransaction.Commit();
                    //return Ok();

                    GenerateInvoicePDF generateInvoicePDF = new GenerateInvoicePDF(viewRenderService, customerInsertQuery.GetResult(), input.PetId, invoiceInsertQuery.GetResult());
                    var pdfdoc =await  generateInvoicePDF.Execute();

                    string fileName = "Invoice_" + invoiceInsertQuery.GetResult().ToString();

                    return  File(pdfdoc.BinaryData, "application/pdf", fileName);
                }
                else
                {
                    dbContextTransaction.Rollback();
                    return BadRequest(new GetRequestError("Appointment Not Inserted").GetResponse());
                }
            }
            catch (InvalidOperationException ex)
            {
                // TODO: log the error
                dbContextTransaction.Rollback();
                return BadRequest(new GetRequestError(ex.ToString()).GetResponse());
            }

            catch (ArgumentException)
            {
                dbContextTransaction.Rollback();
                return BadRequest(ModelState);

            }
        }
    }
}
