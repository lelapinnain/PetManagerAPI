using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.Models.NonQueries;
using PetManager.Models.Quereies;

namespace PetManager.Controllers.PostControllers
{
    public class AddPetInfoController : AbstractControllerPost<AddPetInfoInputDTO>
    {
        [Route("PetManager/AddPetInfo")]
        public override IActionResult Post([FromBody] AddPetInfoInputDTO input)
        {
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                PetInfoInsert petInfoInsert = new PetInfoInsert(input);
            petInfoInsert.RunQuery();

            
          

            if (petInfoInsert.GetResult() == "ok")
            {
                return Ok(petInfoInsert.GetResult());
            }
            else
            {
                return BadRequest("Pet Not Inserted");
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
