using Microsoft.AspNetCore.Mvc;
using PetManager.DTOs.InputDTOs;
using PetManager.Models;
using PetManager.Models.NonQueries;
using PetManager.Models.Quereies;
using PetManager.Utilities;
using PetManager.VaccineValidations;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using PetManager.ErrorHandlers;
using Microsoft.AspNetCore.Authorization;

namespace PetManager.Controllers.PostControllers
{
    public class AddPetVaccinationControler : AbstractControllerPost<AddVaccinationInputDTO>
    {
        [Authorize]
        [Route("PetManager/AddVaccination")]
       

        public override IActionResult Post([FromBody] AddVaccinationInputDTO input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }

                #region Old Vaccine Validation
                // Validate Vaccine
                //GetVaccineHistoryByTypeAndPet getVaccineHistoryByTypeAndPet = new GetVaccineHistoryByTypeAndPet(input.PetId, input.VaccinationId);
                //List<VaccineHistory> vaccineHistories = getVaccineHistoryByTypeAndPet.Execute();

                //GetPetInfoByIDQuery getPetInfoByIDQuery = new GetPetInfoByIDQuery(input.PetId);
                //getPetInfoByIDQuery.RunQuery();
                //PetInfo petInfo = getPetInfoByIDQuery.GetResult();

                //IVaccineValidations vaccineValidations = null;
                //APIResponse response = new APIResponse();
                //if (input.VaccinationId == 1)
                //{
                //    vaccineValidations = new ValidateDAPPV(vaccineHistories, input.VaccinationDate, petInfo.Dob);
                //}

                //if (vaccineValidations != null)
                //{
                //    response = vaccineValidations.validate();
                //}
                #endregion

                // Validate Vaccine
                ValidateVaccines validateVaccines = new ValidateVaccines(input.VaccinationDate, input.PetId, input.VaccinationId);
                APIResponse response = validateVaccines.Execute();

                if (response.Code == APIResponse.ErrorCode.SUCCESS)
                {
                    VaccinationInsertQuery vaccinationInsertQuery = new VaccinationInsertQuery(input);
                    vaccinationInsertQuery.RunQuery();

                    if (vaccinationInsertQuery.GetResult() == "ok")
                    {
                        //return Ok(petInfoInsert.GetResult());
                        return Ok(vaccinationInsertQuery.GetResult());
                    }
                    else
                    {
                        return BadRequest(new GetRequestError("Vaccination Not Inserted").GetResponse());
                    }
                }
                else
                {
                    return BadRequest(response);
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
