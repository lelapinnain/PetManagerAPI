
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.Models.NonQueries;

namespace PetManager.Controllers.PostControllers
{
    public class UserRegisterController : AbstractControllerPost<UserCredentailsDTO>
    {
        [Route("PetManager/Register")]
        public override IActionResult Post([FromBody] UserCredentailsDTO input)
        {
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                RegisterUserQuery registerUser = new RegisterUserQuery(input);
                registerUser.RunQuery();




                if (registerUser.GetResult() == "ok")
                {
                    return Ok(registerUser.GetResult());
                }
                else
                {
                    return BadRequest("User Already Exists");
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
