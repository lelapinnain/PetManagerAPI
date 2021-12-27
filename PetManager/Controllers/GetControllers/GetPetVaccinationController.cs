using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models;
using PetManager.Models.Quereies;

namespace PetManager.Controllers.GetControllers
{
    public class GetPetVaccinationController : AbstractControllerGet<GetPetInfoInputDTO>
    {
        [Authorize]
        [Route("PetManager/VaccinationInfo")]
        public override IActionResult Get([FromQuery] GetPetInfoInputDTO input)
        {
           // return Ok();
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                GetPetInfoVaccinationQuery getPetInfoVaccinationQuery = new GetPetInfoVaccinationQuery(input.PetId);
                getPetInfoVaccinationQuery.RunQuery();

                List<VaccinationView> vaccinations = getPetInfoVaccinationQuery.GetResult();

                if (vaccinations.Count != 0)
                {
                    return Ok(vaccinations);
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
