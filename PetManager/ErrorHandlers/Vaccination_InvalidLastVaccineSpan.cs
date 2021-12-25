namespace PetManager.ErrorHandlers
{
    public class Vaccination_InvalidLastVaccineSpan
    {
        private int lastVaccineSpan;

        public Vaccination_InvalidLastVaccineSpan(int _lastVaccineSpan)
        {
            lastVaccineSpan = _lastVaccineSpan;
        }

        public APIResponse GetResponse()
        {
            return new APIResponse(APIResponse.ErrorCode.ERROR_INVALID_VACCINE, "Date should be " + lastVaccineSpan.ToString() + " weeks far from last dose");
        }
    }
}
