using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models;
using PetManager.Models.Quereies;

namespace PetManager.Controllers.GetControllers
{
    public class GetPetDewormingController : AbstractControllerGet<GetPetInfoInputDTO>
    {
        [Authorize]
        [Route("PetManager/VaccinationInfo")]
        public override async Task< IActionResult> Get([FromQuery] GetPetInfoInputDTO input)
        {
            // return Ok();
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                GetPetInfoDewormingQuery getPetInfoDewormingQuery = new GetPetInfoDewormingQuery(input.PetId);
                await getPetInfoDewormingQuery.RunQuery();

                List<DewormingView> dewormings = getPetInfoDewormingQuery.GetResult();

                if (dewormings.Count != 0)
                {
                    return Ok(dewormings);
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
