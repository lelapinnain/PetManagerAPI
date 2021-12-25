using PetManager.ErrorHandlers;

namespace PetManager.VaccineValidations.VaccineValidationsChain
{
    public class ValidatePetBirthdate : AbstractVaccineValidationStep
    {
        private APIResponse response;
        private DateTime vaccineDate;
        private DateTime petDOB;
        private int dateSpan;

        public ValidatePetBirthdate(DateTime _vaccineDate, DateTime _petDOB, int _dateSpan)
        {
            vaccineDate = _vaccineDate;
            petDOB = _petDOB;
            dateSpan = _dateSpan;
        }

        public override APIResponse validate()
        {
            TimeSpan vaxDateDiff = vaccineDate - petDOB;
            int vaxDateDiffWeeks = vaxDateDiff.Days / 7;

            if (vaxDateDiffWeeks >= dateSpan)
            {
                response = new Vaccination_Valid().GetResponse();
            }
            else
            {
                response = new Vaccination_InvalidBirthdateSpan().GetResponse();
                return response;
            }

            if (response.Code == APIResponse.ErrorCode.SUCCESS && nextValidationStep != null)
            {
                response = nextValidationStep.validate();
            }

            return response;
        }
    }
}
