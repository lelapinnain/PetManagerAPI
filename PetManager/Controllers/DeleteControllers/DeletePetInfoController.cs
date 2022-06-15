
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models.NonQueries;

namespace PetManager.Controllers.DeleteControllers
{
    public class DeletePetInfoController:AbstractControllerDelete<GetPetInfoInputDTO>
    {
        //[Authorize]
        [Route("PetManager/DeletePetInfo")]
        public override async Task< IActionResult> Delete([FromBody] GetPetInfoInputDTO input)
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
               await DeletePetInfoByIDQuery.RunQuery();

                if (DeletePetInfoByIDQuery != null)
                {
                    return Ok(DeletePetInfoByIDQuery.GetResult());
                }
                else
                {
                    return BadRequest(new GetRequestError("Pet Not Found").GetResponse());
                }
            }
            catch (InvalidOperationException ex)
            {
                // TODO: log the error

                return BadRequest(new GetRequestError(ex.ToString()).GetResponse());
            }

            catch(ArgumentException)
            {
                return BadRequest(new GetRequestError(ModelState.Values.Where(w => w.Errors.Count > 0).First().Errors.First().ErrorMessage).GetResponse());
            }

        }
    }
}
