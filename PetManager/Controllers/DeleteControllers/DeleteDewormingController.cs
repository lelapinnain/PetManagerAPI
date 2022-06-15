using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models.NonQueries;

namespace PetManager.Controllers.DeleteControllers
{
    public class DeleteDewormingController : AbstractControllerDelete<DeleteDewormingDTO>
    {
        [Authorize]
        [Route("PetManager/DeleteDeworming")]
        public override async Task< IActionResult> Delete([FromBody] DeleteDewormingDTO input)
        {
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }

                DeleteDewormingByIDQuery deleteDewormingByIDQuery = new DeleteDewormingByIDQuery(input.DewormingHistoryId);
                await deleteDewormingByIDQuery.RunQuery();

                if (deleteDewormingByIDQuery.GetResult() != null)
                {
                    return Ok(deleteDewormingByIDQuery.GetResult());
                }
                else
                {
                    return BadRequest(new GetRequestError("Vaccination Not Found").GetResponse());

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
