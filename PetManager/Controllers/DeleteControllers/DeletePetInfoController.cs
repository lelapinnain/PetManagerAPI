
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.Models.NonQueries;

namespace PetManager.Controllers.DeleteControllers
{
    public class DeletePetInfoController:AbstractControllerDelete<GetPetInfoInputDTO>
    {
        [Route("PetManager/DeletePetInfo")]
        public override IActionResult Delete([FromBody] GetPetInfoInputDTO input)
       // public override IActionResult Delete([FromBody] int PetId)
        {
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }

                DeletePetInfoByIDQuery DeletePetInfoByIDQuery = new DeletePetInfoByIDQuery( input.PetId);
                DeletePetInfoByIDQuery.RunQuery();

                if (DeletePetInfoByIDQuery != null)
                {
                    return Ok(DeletePetInfoByIDQuery.GetResult());
                }
                else
                {
                    return BadRequest("Pet Not Found");
                }
            }
            catch (InvalidOperationException ex)
            {
                // TODO: log the error

                return StatusCode(500, "An error occured");
            }

            catch(ArgumentException)
            {
                return BadRequest(ModelState);
            }

        }
    }
}
