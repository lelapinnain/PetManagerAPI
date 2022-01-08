using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models.NonQueries;

namespace PetManager.Controllers.DeleteControllers
{
    public class DeleteAppointmentController : AbstractControllerDelete<AppointmentInputDTO>
    {
        [Authorize]
        [Route("PetManager/DeleteAppointment")]
        public override IActionResult Delete([FromBody] AppointmentInputDTO input)
        {
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }

                DeleteAppointmentByIDQuery deleteAppointmentByIDQuery = new DeleteAppointmentByIDQuery(input.ApptId);
                deleteAppointmentByIDQuery.RunQuery();

                if (deleteAppointmentByIDQuery.GetResult() == "ok")
                {
                    return Ok(deleteAppointmentByIDQuery.GetResult());
                }
                else
                {
                    return BadRequest(new GetRequestError("Appointment Not Found").GetResponse());
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
