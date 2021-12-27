using PetManager.ErrorHandlers;
using PetManager.Models;
using PetManager.VaccineValidations.VaccineValidationsChain;

namespace PetManager.VaccineValidations
{
    public class ValidateRABIES : IVaccineValidations
    {
        private List<VaccineHistory> vaccineHistories;
        private APIResponse response;
        private DateTime vaccineDate;
        private DateTime petDOB;

        public ValidateRABIES(List<VaccineHistory> _vaccineHistories, DateTime _vaccineDate, DateTime _petDOB)
        {
            vaccineHistories = _vaccineHistories;
            vaccineDate = _vaccineDate;
            petDOB = _petDOB;

            response = new APIResponse();
        }
        public APIResponse validate()
        {
            const int BIRTHDATE_SPAN = 16;
            const int DOSE_LIMIT = 1;

            // Setup chain steps
            ValidatePetBirthdate validatePetBirthdate = new ValidatePetBirthdate(vaccineDate, petDOB, BIRTHDATE_SPAN);
          
            ValidateDoseCount validateDoseCount = new ValidateDoseCount(vaccineHistories, DOSE_LIMIT);

            // Setup the chain connection
            validatePetBirthdate.setNextValidationStep(validateDoseCount);
           

            // Fire the chain execution
            response = validatePetBirthdate.validate();

            return response;
        }
    }
}
