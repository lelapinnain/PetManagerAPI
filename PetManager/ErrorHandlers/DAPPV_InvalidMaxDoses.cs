namespace PetManager.ErrorHandlers
{
    public class DAPPV_InvalidMaxDoses : IErrorHandler
    {
        public APIResponse GetResponse()
        {
            return new APIResponse(APIResponse.ErrorCode.ERROR_INVALID_VACCINE, "DAPPV Vaccine: Max number of doses is 4");
        }
    }
}
