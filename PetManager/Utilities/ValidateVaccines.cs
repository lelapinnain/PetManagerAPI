using PetManager.ErrorHandlers;
using PetManager.Models;
using PetManager.Models.Quereies;
using PetManager.VaccineValidations;

namespace PetManager.Utilities
{
    public class ValidateVaccines : IUtility<APIResponse>
    {
        private enum vaccinationType
        {
            INTRATRAC3  = 1,
            DAPPV,
            RABIES
        }

        private DateTime vaccinationDate;
        private int petId;
        private int vaccinationId;
        private APIResponse response;

        public ValidateVaccines(DateTime _vaccinationDate, int _petId, int _vaccinationId)
        {
            vaccinationDate = _vaccinationDate;
            petId = _petId;
            vaccinationId = _vaccinationId;

            response = new APIResponse();
        }

        public APIResponse Execute()
        {
            GetVaccineHistoryByTypeAndPet getVaccineHistoryByTypeAndPet = new GetVaccineHistoryByTypeAndPet(petId, vaccinationId);
            List<VaccineHistory> vaccineHistories = getVaccineHistoryByTypeAndPet.Execute();

            GetPetInfoByIDQuery getPetInfoByIDQuery = new GetPetInfoByIDQuery(petId);
            getPetInfoByIDQuery.RunQuery();
            PetInfo petInfo = getPetInfoByIDQuery.GetResult();

            IVaccineValidations vaccineValidations = null;

            if (vaccinationId == Convert.ToInt32(vaccinationType.DAPPV))
            {
                vaccineValidations = new ValidateDAPPV(vaccineHistories, vaccinationDate, petInfo.Dob);
            }

            if (vaccinationId == Convert.ToInt32(vaccinationType.INTRATRAC3))
            {
                vaccineValidations = new ValidateINTRATRAC3(vaccineHistories, vaccinationDate, petInfo.Dob);
            }
            if (vaccinationId == Convert.ToInt32(vaccinationType.RABIES))
            {
                vaccineValidations = new ValidateRABIES(vaccineHistories, vaccinationDate, petInfo.Dob);
            }

            if (vaccineValidations != null)
            {
                response = vaccineValidations.validate();
            }

            return response;
        }
    }
}
