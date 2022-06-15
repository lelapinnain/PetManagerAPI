using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models.NonQueries;

namespace PetManager.Controllers.PutControllers
{
    public class UpdatePetDewormingController : AbstractControllerPut<AddDewormingInputDTO>
    {
        [Authorize]
        [Route("PetManager/UpdateDeworming")]
        public override async Task< IActionResult> Put([FromBody] AddDewormingInputDTO input)
        {
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }


                UpdateDewormingByIDQuery updateDewormingByIDQuery = new UpdateDewormingByIDQuery(input);
                await updateDewormingByIDQuery.RunQuery();

                    if (updateDewormingByIDQuery.GetResult() != null)
                    {
                        return Ok(updateDewormingByIDQuery.GetResult());
                    }
                    else
                    {
                        return BadRequest(new GetRequestError("Deworming Not Updated").GetResponse());
                    }
               
            }
            catch (InvalidOperationException ex)
            {
                // TODO: log the error

                return BadRequest(new GetRequestError(ex.ToString()).GetResponse());
            }

            catch (ArgumentException)
            {
                return BadRequest(ModelState);
            }

        }
    }
}
