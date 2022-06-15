using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models.NonQueries;

namespace PetManager.Controllers.PutControllers
{
    [Authorize]
    [Route("PetManager/UpdateAppointment")]
    public class UpdateAppointmentController : AbstractControllerPut<AppointmentInputDTO>
    {
        public override async Task< IActionResult> Put([FromBody] AppointmentInputDTO input)
        {
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                UpdateAppointmentByIDQuery updateAppointmentByIDQuery = new UpdateAppointmentByIDQuery(input);
                await updateAppointmentByIDQuery.RunQuery();

              


                if (updateAppointmentByIDQuery.GetResult() == "ok")
                {
                    return Ok(updateAppointmentByIDQuery.GetResult());
                }
                else
                {
                    return BadRequest(new GetRequestError("Appointment Not Updated").GetResponse());
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
