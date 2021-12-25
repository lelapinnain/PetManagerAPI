using PetManager.ErrorHandlers;
using PetManager.Models;

namespace PetManager.VaccineValidations.VaccineValidationsChain
{
    public class ValidateLastVaccine : AbstractVaccineValidationStep
    {
        private APIResponse response;
        private DateTime vaccineDate;
        private List<VaccineHistory> vaccineHistories;
        private int dateSpan;

        public ValidateLastVaccine(DateTime _vaccineDate, List<VaccineHistory> _vaccineHistories, int _dateSpan)
        {
            vaccineDate = _vaccineDate;
            vaccineHistories = _vaccineHistories;
            dateSpan = _dateSpan;
        }

        public override APIResponse validate()
        {
            VaccineHistory? lastVaccineHistory = vaccineHistories.FirstOrDefault();
            if (lastVaccineHistory != null)
            {
                TimeSpan vaxLastDateDiff = vaccineDate - lastVaccineHistory.VaccineDate.Value;
                int vaxLastDateDiffWeeks = vaxLastDateDiff.Days / 7;

                if (vaxLastDateDiffWeeks >= dateSpan)
                {
                    response = new Vaccination_Valid().GetResponse();
                }
                else
                {
                    response = new Vaccination_InvalidLastVaccineSpan(dateSpan).GetResponse();
                    return response;
                }
            }
            else
            {
                response = new Vaccination_Valid().GetResponse();
            }

            if (response.Code == APIResponse.ErrorCode.SUCCESS && nextValidationStep != null)
            {
                response = nextValidationStep.validate();
            }

            return response;
        }
    }
}
