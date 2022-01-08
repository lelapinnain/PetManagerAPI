using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models.NonQueries;

namespace PetManager.Controllers.PostControllers
{
    [Authorize]
    [Route("PetManager/AddAppointment")]
    public class AddApointmentController : AbstractControllerPost<AppointmentInputDTO>
    {
        public override IActionResult Post([FromBody] AppointmentInputDTO input)
        {
            try
            {
               
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                AppointmentInsertQuery appointmentInsertQuery = new AppointmentInsertQuery(input);
                appointmentInsertQuery.RunQuery();

                if (appointmentInsertQuery.GetResult() == "ok")

                {
                    //return Ok(petInfoInsert.GetResult());
                    return Ok();
                }
                else
                {
                    return BadRequest(new GetRequestError("Appointment Not Inserted").GetResponse());
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
