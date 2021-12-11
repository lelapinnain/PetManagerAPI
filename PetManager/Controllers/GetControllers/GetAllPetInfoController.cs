using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.Mappers;
using PetManager.DTOs.OutputDTOs;
using PetManager.Models.Quereies;

namespace PetManager.Controllers.GetControllers
{
    public class GetAllPetInfoController : AbstractControllerGetNoType
    {
        [Authorize]
        [Route("PetManager/GetAllPetInfo")]
        public override IActionResult Get()
        {
            GetAllPetInfoQuery getAllPetInfoQuery = new GetAllPetInfoQuery();
            getAllPetInfoQuery.RunQuery();

            GetAllPetInfoMapper getAllPetInfoMapper = new GetAllPetInfoMapper(getAllPetInfoQuery.GetResult());
            List<GetPetInfoOutputDTO> getPetInfoOutputDTOList = getAllPetInfoMapper.GetMappedDTO();

            if (getPetInfoOutputDTOList != null)
            {
                return Ok(getPetInfoOutputDTOList);
            }
            else
            {
                return BadRequest("Pet Not Found");
            }
        }
    }
}
