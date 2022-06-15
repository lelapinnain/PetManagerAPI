
using PetManager.DTOs.InputDTOs;
using Microsoft.AspNetCore.Mvc;
using PetManager.Models.NonQueries;
using PetManager.DTOs.Mappers;
using PetManager.DTOs.OutputDTOs;
using Microsoft.AspNetCore.Authorization;
using PetManager.ErrorHandlers;

namespace PetManager.Controllers.PutControllers
{

        public class UpdatePetInfoController : AbstractControllerPut<UpdatePetInfoDTO>
        {
        [Authorize]
        [Route("PetManager/UpdatePetInfo")]
            public override async Task< IActionResult> Put([FromBody] UpdatePetInfoDTO input)
            {

            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                UpdatePetInfoByIDQuery updatePetInfoByIDQuery = new UpdatePetInfoByIDQuery(input);
                await updatePetInfoByIDQuery.RunQuery();

                UpdatePetInfoByIDMapper UpdatePetInfoMapper = new UpdatePetInfoByIDMapper(updatePetInfoByIDQuery.GetResult());
                UpdatePetInfoDTO updatePetInfoOutputDTO = UpdatePetInfoMapper.GetMappedDTO();


                if (updatePetInfoOutputDTO != null)
                {
                    return Ok(updatePetInfoOutputDTO);
                }
                else
                {
                    return BadRequest(new GetRequestError("Pet Not Updated").GetResponse());
                }
            }
            catch (InvalidOperationException ex)
            {
                // TODO: log the error

                return BadRequest(new GetRequestError(ex.ToString()).GetResponse());
            }

            catch (ArgumentException)
            {
                return BadRequest(ModelState);
            }
        }
        }
    }

