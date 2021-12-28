using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models.NonQueries;

namespace PetManager.Controllers.PostControllers
{
    public class AddPetDewormingController : AbstractControllerPost<AddDewormingInputDTO>
    {
        [Authorize]
        [Route("PetManager/AddDeworming")]


        public override IActionResult Post([FromBody] AddDewormingInputDTO input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }


                // Validate Vaccine

                DewormingInsertQuery dewormingInsertQuery = new DewormingInsertQuery(input);
                dewormingInsertQuery.RunQuery();

                if (dewormingInsertQuery.GetResult() == "ok")
                {
                    //return Ok(petInfoInsert.GetResult());
                    return Ok(dewormingInsertQuery.GetResult());
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
