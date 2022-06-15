

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetManager.Authentication;
using PetManager.DTOs.InputDTOs;
using PetManager.DTOs.Mappers;
using PetManager.DTOs.OutputDTOs;
using PetManager.Models;
using PetManager.Models.Quereies;
using System.Net;
using System.Text;

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
        public override async Task< IActionResult> Get([FromQuery] UserCredentailsDTO userCredential)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }

                LoginQuery loginQuery = new LoginQuery(userCredential, jwtAuth);
                 await loginQuery.RunQuery();

                var token =  loginQuery.GetResult();

                if (token != null)
                {
                    User user = loginQuery.CustomerInfo();
                    // var expected = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user ));
                    // Console.WriteLine(user);
                    //GetUserInfoMapper getUserInfoMapper = new GetUserInfoMapper(user, token);

                    //return Ok(token);
                    return Ok(new GetUserInfoMapper(user, token).GetMappedDTO());
                }
                else
                {
                    return BadRequest(new ErrorResponse(HttpStatusCode.Forbidden, "Incorrect Credentials"));
                    //return BadRequest("Incorrect Credentials");
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
