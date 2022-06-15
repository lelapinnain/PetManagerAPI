using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.DTOs.Mappers;
using PetManager.ErrorHandlers;
using PetManager.Models;
using PetManager.Models.Quereies;

namespace PetManager.Controllers.GetControllers
{
    public class GetDailyAppointmentController : AbstractControllerGet<AppointmentInputDTO>
    {

       [Authorize]
        [Route("PetManager/GetAppointmentByDate")]
        public override async Task<IActionResult> Get([FromQuery] AppointmentInputDTO input)
        {
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                GetAppointmentByDateQuery getAppointmentByDateQuery =  new GetAppointmentByDateQuery(Convert.ToDateTime( input.AppointmentDate));
                await getAppointmentByDateQuery.RunQuery();

                GetAppointmentMapper getAppointmentMapper = new GetAppointmentMapper(getAppointmentByDateQuery.GetResult());
                List<AppointmentRecord> appointments = getAppointmentMapper.GetMappedDTO();

                if (appointments.Count != 0)
                {
                    return Ok(appointments );
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
