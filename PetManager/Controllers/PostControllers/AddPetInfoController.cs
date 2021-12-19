using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.Models.NonQueries;
using PetManager.Models.Quereies;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace PetManager.Controllers.PostControllers
{
    public class AddPetInfoController : AbstractControllerPost<AddPetInfoInputDTO>
    {
        [Route("PetManager/AddPetInfo")]
        public override IActionResult Post([FromBody] AddPetInfoInputDTO input)
        //  public override IActionResult Post()
        {
            try
            {
                var base64Data = Regex.Match(input.Images, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                var binData = Convert.FromBase64String(base64Data);

                System.IO.File.WriteAllBytes("E:\\TestFile.png", binData);

                //string base64 = System.Convert.ToBase64String(b);
                //b = Encoding.ASCII.GetBytes(base64);
                //var txtStream = new MemoryStream(b);
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                PetInfoInsertQuery petInfoInsert = new PetInfoInsertQuery(input);
                petInfoInsert.RunQuery();


                // var request = HttpContext.Request;



                //if (petInfoInsert.GetResult() == "ok")
                if (true)
                {
                    //return Ok(petInfoInsert.GetResult());
                    return Ok();
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
