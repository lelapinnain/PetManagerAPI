using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.Models.NonQueries;

namespace PetManager.Controllers.PutControllers
{
    public class UpdatePetVaccinationController : AbstractControllerPut<AddVaccinationInputDTO>
    {
        [Route("PetManager/UpdateVaccination")]
        public override IActionResult Put([FromBody] AddVaccinationInputDTO input)
        {
             try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                UpdateVaccinationByIDQuery updateVaccinationByIDQuery = new UpdateVaccinationByIDQuery(input);
                updateVaccinationByIDQuery.RunQuery();

                


                if (updateVaccinationByIDQuery.GetResult() != null)
                {
                    return Ok(updateVaccinationByIDQuery.GetResult());
                }
                else
                {
                    return BadRequest("Vaccine Not Updated");
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
