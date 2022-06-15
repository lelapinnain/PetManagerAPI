using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DailyVaccines;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models.Quereies;

namespace PetManager.Controllers.GetControllers
{
    public class GetDailyVaccinations : AbstractControllerGet<GetDailyVaccinationsInputDTO>
    {
        [Authorize]
        [Route("PetManager/GetDailyVaccinations")]
        public override async Task< IActionResult> Get([FromHeader] GetDailyVaccinationsInputDTO input)
        {
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }

                IDailyVaccines dailyVaccines = null;

                if (input.VaccineType == 1)
                {
                    dailyVaccines = new INTRATRACDailyVaccines();
                }

                if (input.VaccineType == 2)
                {
                    dailyVaccines = new DAPPVDailyVaccines();
                }

                if (input.VaccineType == 3)
                {
                    dailyVaccines = new RABIESDailyVaccines();
                }

                if (dailyVaccines != null)
                {
                    return Ok(await dailyVaccines.GetDailyVaccines());
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
