﻿using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.Models.NonQueries;

namespace PetManager.Controllers.DeleteControllers
{
    public class DeleteVaccination : AbstractControllerDelete<DeleteVaccineDTO>
    {
        [Route("PetManager/DeleteVaccination")]
        public override IActionResult Delete([FromBody] DeleteVaccineDTO input)
        {
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }

                DeleteVaccineByIDQuery deleteVaccineByIDQuery = new DeleteVaccineByIDQuery(input.Id);
                deleteVaccineByIDQuery.RunQuery();

                if (deleteVaccineByIDQuery.GetResult() != null)
                {
                    return Ok(deleteVaccineByIDQuery.GetResult());
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

            catch (ArgumentException)
            {
                return BadRequest(ModelState);
            }

        }
    }
}