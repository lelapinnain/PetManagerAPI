using PetManager.ErrorHandlers;
using PetManager.Models;

namespace PetManager.VaccineValidations.VaccineValidationsChain
{
    public class ValidateDoseCount : AbstractVaccineValidationStep
    {
        private APIResponse response;
        private List<VaccineHistory> vaccineHistories;
        private int dateSpan;

        public ValidateDoseCount(List<VaccineHistory> _vaccineHistories, int _dateSpan)
        {
            vaccineHistories = _vaccineHistories;
            dateSpan = _dateSpan;
        }

        public override APIResponse validate()
        {
            if (vaccineHistories.Count < dateSpan)
            {
                response = new Vaccination_Valid().GetResponse();
            }
            else
            {
                response = new Vaccination_InvalidMaxDoses(dateSpan).GetResponse();
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
