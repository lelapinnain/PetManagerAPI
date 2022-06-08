using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.ErrorHandlers;
using PetManager.Models.Quereies;

namespace PetManager.Controllers.GetControllers
{
    public class GetInvoicesAllController : AbstractControllerGetNoType
    {
        [Authorize]
        [Route("PetManager/GetInvoicesAll")]
        public override IActionResult Get()
        {
            GetInvoicesAllQuery getInvoicesAllQuery = new GetInvoicesAllQuery();
            getInvoicesAllQuery.RunQuery();

            //GetAllPetInfoMapper getAllPetInfoMapper = new GetAllPetInfoMapper(getAllPetInfoQuery.GetResult());
            //List<GetPetInfoOutputDTO> getPetInfoOutputDTOList = getAllPetInfoMapper.GetMappedDTO();

            if (getInvoicesAllQuery != null)
            {
                return Ok(getInvoicesAllQuery.GetResult());
            }
            else
            {
                //return BadRequest("Pet Not Found");
                return BadRequest(new GetRequestError("No Data Found").GetResponse());
            }
        }


    }
}
