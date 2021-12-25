namespace PetManager.ErrorHandlers
{
    public class Vaccination_InvalidBirthdateSpan : IErrorHandler
    {
        public APIResponse GetResponse()
        {
            return new APIResponse(APIResponse.ErrorCode.ERROR_INVALID_VACCINE, "Puppy's age has to be at least 5 weeks");
        }
    }
}
