using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.ErrorHandlers;
using PetManager.Models;
using PetManager.Models.Quereies;

namespace PetManager.Controllers.GetControllers
{
    public class GetInvoiceDetails : AbstractControllerGet<int>
    {
        [Authorize]
        [Route("PetManager/GetInvoiceDetails")]
        public override async Task< IActionResult> Get([FromQuery] int id)
        {
            // return Ok();
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                GetInvoiceDetailsByIDQuery getInvoiceDetailsByIDQuery = new GetInvoiceDetailsByIDQuery(id);
               await getInvoiceDetailsByIDQuery.RunQuery();

                

               

                if (getInvoiceDetailsByIDQuery.GetResult() != null)
                {
                    return Ok(getInvoiceDetailsByIDQuery.GetResult());
                }
                else
                {
                    //return BadRequest("Pet Not Found");
                    return BadRequest(new GetRequestError("Invoice Not Found").GetResponse());
                }
            }
            catch (InvalidOperationException ex)
            {
                //return StatusCode(500, "An error occured");
                return BadRequest(new GetRequestError(ex.ToString()).GetResponse());
            }
            catch (ArgumentException)
            {
                //return BadRequest(ModelState);
                return BadRequest(new GetRequestError(ModelState.Values.Where(w => w.Errors.Count > 0).First().Errors.First().ErrorMessage).GetResponse());
            }
        }

       
    }
}
