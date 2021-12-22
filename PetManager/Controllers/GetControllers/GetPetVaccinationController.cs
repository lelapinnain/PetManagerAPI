using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.Models;
using PetManager.Models.Quereies;

namespace PetManager.Controllers.GetControllers
{
    public class GetPetVaccinationController : AbstractControllerGet<GetPetInfoInputDTO>
    {
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
                    return BadRequest("No Data Found");
                }
            }
            catch (InvalidOperationException ex)
            {
                // TODO: log the error

                return StatusCode(500, "An error occured");
            }

            catch (ArgumentException)
            {
                return BadRequest(ModelState);
            }
        }
    }
}
