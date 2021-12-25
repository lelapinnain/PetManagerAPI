namespace PetManager.ErrorHandlers
{
    public class DAPPV_InvalidLastVaccineSpan
    {
        public APIResponse GetResponse()
        {
            return new APIResponse(APIResponse.ErrorCode.ERROR_INVALID_VACCINE, "DAPPV Vaccine: Date should be 3 weeks far from last dose");
        }
    }
}
