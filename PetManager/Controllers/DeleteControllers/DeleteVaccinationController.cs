using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models.NonQueries;

namespace PetManager.Controllers.DeleteControllers
{
    public class DeleteVaccinationController : AbstractControllerDelete<DeleteVaccineDTO>
    {
        [Authorize]
        [Route("PetManager/DeleteVaccination")]
        public override IActionResult Delete([FromBody] DeleteVaccineDTO input)
        {
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }

                DeleteVaccineByIDQuery deleteVaccineByIDQuery = new DeleteVaccineByIDQuery(input.Id);
                deleteVaccineByIDQuery.RunQuery();

                if (deleteVaccineByIDQuery.GetResult() != null)
                {
                    return Ok(deleteVaccineByIDQuery.GetResult());
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
