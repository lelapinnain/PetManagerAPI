
using PetManager.DTOs.InputDTOs;
using Microsoft.AspNetCore.Mvc;
using PetManager.Models.NonQueries;
using PetManager.DTOs.Mappers;
using PetManager.DTOs.OutputDTOs;

namespace PetManager.Controllers.PutControllers
{

        public class UpdatePetInfoController : AbstractControllerPut<UpdatePetInfoDTO>
        {
            [Route("PetManager/UpdatePetInfo")]
            public override IActionResult Put([FromBody] UpdatePetInfoDTO input)
            {

            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                UpdatePetInfoByIDQuery updatePetInfoByIDQuery = new UpdatePetInfoByIDQuery(input);
                updatePetInfoByIDQuery.RunQuery();

                UpdatePetInfoByIDMapper UpdatePetInfoMapper = new UpdatePetInfoByIDMapper(updatePetInfoByIDQuery.GetResult());
                UpdatePetInfoDTO updatePetInfoOutputDTO = UpdatePetInfoMapper.GetMappedDTO();


                if (updatePetInfoOutputDTO != null)
                {
                    return Ok(updatePetInfoOutputDTO);
                }
                else
                {
                    return BadRequest("Pet Not Updated");
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

