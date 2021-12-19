using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.DTOs.Mappers;
using PetManager.DTOs.OutputDTOs;
using PetManager.Models.Quereies;


namespace PetManager.Controllers.GetControllers
{
    public class GetPetInfoController : AbstractControllerGet<GetPetInfoInputDTO>
    {
        
        [Route("PetManager/GetPetInfo")]
        public override IActionResult Get([FromQuery] GetPetInfoInputDTO input)
        {
            try
            {
                // check the input DTO validation
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                GetPetInfoByIDQuery getPetInfoByIDQuery = new GetPetInfoByIDQuery(input.PetId);
                getPetInfoByIDQuery.RunQuery();

                GetPetInfoVaccinationQuery getPetInfoVaccinationQuery = new GetPetInfoVaccinationQuery(input.PetId);
                getPetInfoVaccinationQuery.RunQuery();

                GetPetInfoByIDMapper getPetInfoByIDMapper = new GetPetInfoByIDMapper(getPetInfoByIDQuery.GetResult(), getPetInfoVaccinationQuery.GetResult());
                GetPetInfoOutputDTO getPetInfoOutputDTO = getPetInfoByIDMapper.GetMappedDTO();

                if (getPetInfoOutputDTO != null)
                {
                    return Ok(getPetInfoOutputDTO);
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
