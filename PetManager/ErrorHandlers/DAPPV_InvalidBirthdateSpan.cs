namespace PetManager.ErrorHandlers
{
    public class DAPPV_InvalidBirthdateSpan : IErrorHandler
    {
        public APIResponse GetResponse()
        {
            return new APIResponse(APIResponse.ErrorCode.ERROR_INVALID_VACCINE, "DAPPV Vaccine: Puppy's age has to be at least 5 weeks");
        }
    }
}
