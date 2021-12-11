

using Microsoft.AspNetCore.Mvc;
using PetManager.Authentication;
using PetManager.DTOs.InputDTOs;
using PetManager.Models.Quereies;

namespace PetManager.Controllers.GetControllers
{
    public class LoginController : AbstractControllerGet<UserCredentailsDTO>
    {
        private readonly IJwtAuth jwtAuth;


        public LoginController(IJwtAuth jwtAuth)
        {
            this.jwtAuth = jwtAuth;
        }

        [Route("PetManager/Login")]
        public override IActionResult Get([FromQuery] UserCredentailsDTO userCredential)
        {
            LoginQuery loginQuery = new LoginQuery(userCredential , jwtAuth);
            loginQuery.RunQuery();

            var token = loginQuery.GetResult();

            if (token != null)
            {
                return Ok(token);
            }
            else
            {
                return BadRequest("Incorrect Credentials");
            }
        }
    }
}
