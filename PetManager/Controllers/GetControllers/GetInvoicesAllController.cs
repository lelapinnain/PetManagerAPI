using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models.Quereies;
using PetManager.Utilities;
using PetManager.Utilities.Paging;

namespace PetManager.Controllers.GetControllers
{
    public class GetInvoicesAllController : AbstractControllerGet<PagingParams>
    {
        [Authorize]
        [Route("PetManager/GetInvoicesAll")]
        public async override Task<IActionResult> Get([FromQuery] PagingParams pagingParams)
        {
            GetInvoicesAllQuery getInvoicesAllQuery = new GetInvoicesAllQuery(pagingParams);
            await getInvoicesAllQuery.RunQuery();

            //GetAllPetInfoMapper getAllPetInfoMapper = new GetAllPetInfoMapper(getAllPetInfoQuery.GetResult());
            //List<GetPetInfoOutputDTO> getPetInfoOutputDTOList = getAllPetInfoMapper.GetMappedDTO();

            if (getInvoicesAllQuery != null)
            {
                var result = getInvoicesAllQuery.GetResult();
                Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
                return Ok(result);
            }
            else
            {
                //return BadRequest("Pet Not Found");
                return BadRequest(new GetRequestError("No Data Found").GetResponse());
            }
        }


    }
}
