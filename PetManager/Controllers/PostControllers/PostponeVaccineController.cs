using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models.NonQueries;

namespace PetManager.Controllers.PostControllers
{
    public class PostponeVaccineController : AbstractControllerPost<GetPetInfoInputDTO>
    {
        [Authorize]
        [Route("PetManager/PostponeVaccine")]
        public async override Task<IActionResult> Post([FromBody] GetPetInfoInputDTO input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }

                PostponeVaccineQuery postponeVaccineQuery = new PostponeVaccineQuery(input.PetId);
               await postponeVaccineQuery.RunQuery();

                    if (postponeVaccineQuery.GetResult() == "ok")
                    {
                        //return Ok(petInfoInsert.GetResult());
                        return Ok(postponeVaccineQuery.GetResult());
                    }
                    else
                    {
                        return BadRequest(new GetRequestError("Vaccination Not Inserted").GetResponse());
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
