using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.Models.NonQueries;
using PetManager.Models.Quereies;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
namespace PetManager.Controllers.PostControllers
{
    public class AddPetVaccinationControler : AbstractControllerPost<AddVaccinationInputDTO>
    {

        [Route("PetManager/AddVaccination")]
       

        public override IActionResult Post([FromBody] AddVaccinationInputDTO input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                VaccinationInsertQuery vaccinationInsertQuery = new VaccinationInsertQuery(input);
                vaccinationInsertQuery.RunQuery();

                if (vaccinationInsertQuery.GetResult()=="ok")
                {
                    //return Ok(petInfoInsert.GetResult());
                    return Ok(vaccinationInsertQuery.GetResult());
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
