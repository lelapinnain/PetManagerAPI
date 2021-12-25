﻿using PetManager.ErrorHandlers;
using PetManager.Models;
using PetManager.VaccineValidations.VaccineValidationsChain;

namespace PetManager.VaccineValidations
{
    public class ValidateINTRATRAC3 : IVaccineValidations
    {
        private List<VaccineHistory> vaccineHistories;
        private APIResponse response;
        private DateTime vaccineDate;
        private DateTime petDOB;

        public ValidateINTRATRAC3(List<VaccineHistory> _vaccineHistories, DateTime _vaccineDate, DateTime _petDOB)
        {
            vaccineHistories = _vaccineHistories;
            vaccineDate = _vaccineDate;
            petDOB = _petDOB;

            response = new APIResponse();
        }

        public APIResponse validate()
        {
            #region Old validations implementation
            //// Validate 5 weeks span from birthdate
            //TimeSpan vaxDateDiff = vaccineDate - petDOB;
            //int vaxDateDiffWeeks = vaxDateDiff.Days / 7;

            //if (vaxDateDiffWeeks >= 5)
            //{
            //    response = new Vaccination_Valid().GetResponse();
            //}
            //else
            //{
            //    response = new Vaccination_InvalidBirthdateSpan().GetResponse();
            //    return response;
            //}

            //// Validate 2 weeks span from last DAPPV
            //VaccineHistory? lastVaccineHistory = vaccineHistories.FirstOrDefault();
            //if (lastVaccineHistory != null)
            //{
            //    TimeSpan vaxLastDateDiff = vaccineDate - lastVaccineHistory.VaccineDate.Value;
            //    int vaxLastDateDiffWeeks = vaxLastDateDiff.Days / 7;

            //    if (vaxLastDateDiffWeeks >= 2)
            //    {
            //        response = new Vaccination_Valid().GetResponse();
            //    }
            //    else
            //    {
            //        response = new Vaccination_InvalidLastVaccineSpan(2).GetResponse();
            //        return response;
            //    }
            //}

            //// Validate max DAPPV doses not more than 3
            //if (vaccineHistories.Count < 3)
            //{
            //    response = new Vaccination_Valid().GetResponse();
            //}
            //else
            //{
            //    response = new Vaccination_InvalidMaxDoses(3).GetResponse();
            //    return response;
            //}
            #endregion

            // Validations Chain
            const int BIRTHDATE_SPAN = 5;
            const int LAST_VACCINE_SPAN = 2;
            const int DOSE_LIMIT = 3;

            // Setup chain steps
            ValidatePetBirthdate validatePetBirthdate = new ValidatePetBirthdate(vaccineDate, petDOB, BIRTHDATE_SPAN);
            ValidateLastVaccine validateLastVaccine = new ValidateLastVaccine(vaccineDate, vaccineHistories, LAST_VACCINE_SPAN);
            ValidateDoseCount validateDoseCount = new ValidateDoseCount(vaccineHistories, DOSE_LIMIT);

            // Setup the chain connection
            validatePetBirthdate.setNextValidationStep(validateLastVaccine);
            validateLastVaccine.setNextValidationStep(validateDoseCount);

            // Fire the chain execution
            response = validatePetBirthdate.validate();

            return response;
        }
    }
}
