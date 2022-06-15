using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models.NonQueries;
using PetManager.Utilities;

namespace PetManager.Controllers.PutControllers
{
    public class UpdatePetVaccinationController : AbstractControllerPut<AddVaccinationInputDTO>
    {
        [Authorize]
        [Route("PetManager/UpdateVaccination")]
        public override async Task<IActionResult> Put([FromBody] AddVaccinationInputDTO input)
        {
             try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }

                ValidateVaccines validateVaccines = new ValidateVaccines(input.VaccinationDate, input.PetId, input.VaccinationId);
                APIResponse response = await validateVaccines.Execute();

                if (response.Code == APIResponse.ErrorCode.SUCCESS)
                {
                    UpdateVaccinationByIDQuery updateVaccinationByIDQuery = new UpdateVaccinationByIDQuery(input);
                   await  updateVaccinationByIDQuery.RunQuery();

                    if (updateVaccinationByIDQuery.GetResult() != null)
                    {
                        return Ok(updateVaccinationByIDQuery.GetResult());
                    }
                    else
                    {
                        return BadRequest(new GetRequestError("Vaccine Not Updated").GetResponse());
                    }
                }
                else
                {
                    return BadRequest(response);
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
