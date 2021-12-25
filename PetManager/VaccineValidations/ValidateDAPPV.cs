using PetManager.ErrorHandlers;
using PetManager.Models;

namespace PetManager.VaccineValidations
{
    public class ValidateDAPPV : IVaccineValidations
    {
        private List<VaccineHistory> vaccineHistories;
        private APIResponse response;
        private DateTime vaccineDate;
        private DateTime petDOB;

        public ValidateDAPPV(List<VaccineHistory> _vaccineHistories, DateTime _vaccineDate, DateTime _petDOB)
        {
            vaccineHistories = _vaccineHistories;
            vaccineDate = _vaccineDate;
            petDOB = _petDOB;

            response = new APIResponse();
        }

        public APIResponse validate()
        {
            // Validate 5 weeks span from birthdate
            TimeSpan vaxDateDiff = vaccineDate - petDOB;
            int vaxDateDiffWeeks = vaxDateDiff.Days / 7;

            if (vaxDateDiffWeeks >= 5)
            {
                response = new DAPPV_Valid().GetResponse();
            }
            else
            {
                response = new DAPPV_InvalidBirthdateSpan().GetResponse();
                return response;
            }

            // Validate 3 weeks span from last DAPPV
            VaccineHistory? lastVaccineHistory = vaccineHistories.FirstOrDefault();
            if (lastVaccineHistory != null)
            {
                TimeSpan vaxLastDateDiff = vaccineDate - lastVaccineHistory.VaccineDate.Value;
                int vaxLastDateDiffWeeks = vaxLastDateDiff.Days / 7;

                if (vaxLastDateDiffWeeks >= 3)
                {
                    response = new DAPPV_Valid().GetResponse();
                }
                else
                {
                    response = new DAPPV_InvalidLastVaccineSpan().GetResponse();
                    return response;
                }
            }

            // Validate max DAPPV doses not more than 4
            if (vaccineHistories.Count < 4)
            {
                response = new DAPPV_Valid().GetResponse();
            }
            else
            {
                response = new DAPPV_InvalidMaxDoses().GetResponse();
                return response;
            }

            return response;
        }
    }
}
