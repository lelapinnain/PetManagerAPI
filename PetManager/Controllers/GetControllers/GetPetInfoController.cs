using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.DTOs.Mappers;
using PetManager.DTOs.OutputDTOs;
using PetManager.ErrorHandlers;
using PetManager.Models.Quereies;


namespace PetManager.Controllers.GetControllers
{
    public class GetPetInfoController : AbstractControllerGet<GetPetInfoInputDTO>
    {
        [Authorize]
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
                    //return BadRequest("Pet Not Found");
                    return BadRequest(new GetRequestError("Pet Not Found").GetResponse());
                }
            }
            catch (InvalidOperationException ex)
            {
                //return StatusCode(500, "An error occured");
                return BadRequest(new GetRequestError(ex.ToString()).GetResponse());
            }
            catch (ArgumentException)
            {
                //return BadRequest(ModelState);
                return BadRequest(new GetRequestError(ModelState.Values.Where(w => w.Errors.Count > 0).First().Errors.First().ErrorMessage).GetResponse());
            }
        }
    }
}
