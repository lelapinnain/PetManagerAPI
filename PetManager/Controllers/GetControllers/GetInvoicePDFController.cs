using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models;
using PetManager.Models.Quereies;
using PetManager.Utilities;

namespace PetManager.Controllers.GetControllers
{
    public class GetInvoicePDFController : AbstractControllerGet<GetInvoicePDFInputDTO>
    {
        private readonly IViewRenderService viewRenderService;

        public GetInvoicePDFController(IViewRenderService _viewRenderService)
        {
            viewRenderService = _viewRenderService;
        }

        //[Authorize]
        [Route("PetManager/GetInvoicePDF")]
        public override IActionResult Get([FromBody] GetInvoicePDFInputDTO input)
        {
           // return Ok();
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }

                InvoiveTemplateModel viewModel = new InvoiveTemplateModel();

                GetCustomerInfoByIDQuery getCustomerInfoByIDQuery = new GetCustomerInfoByIDQuery(input.CustomerId);
                getCustomerInfoByIDQuery.RunQuery();
                viewModel.Customer = getCustomerInfoByIDQuery.GetResult();

                GetPetInfoByIDQuery getPetInfoByIDQuery = new GetPetInfoByIDQuery(input.PetId);
                getPetInfoByIDQuery.RunQuery();
                viewModel.PetInfo = getPetInfoByIDQuery.GetResult();

                string result = viewRenderService.RenderToStringAsync("InvoiceTemplate", viewModel);

                IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();

                Renderer.PrintOptions.MarginBottom = 10;
                Renderer.PrintOptions.MarginTop = 10;
                Renderer.PrintOptions.MarginLeft = 10;
                Renderer.PrintOptions.MarginRight = 10;

                var pdfdoc = Renderer.RenderHtmlAsPdf(result);

                string fileName = "TestPDF.pdf";

                if (true)
                {
                    //return Ok(result);
                    return File(pdfdoc.BinaryData, "application/pdf", fileName);
                }
                else
                {
                    return BadRequest(new GetRequestError("No Data Found").GetResponse());
                }
            }
            catch (InvalidOperationException ex)
            {
                // TODO: log the error

                return BadRequest(new GetRequestError(ex.ToString()).GetResponse());
            }

            catch (ArgumentException)
            {
                return BadRequest(new GetRequestError(ModelState.Values.Where(w => w.Errors.Count > 0).First().Errors.First().ErrorMessage).GetResponse());
            }
        }
    }
}
