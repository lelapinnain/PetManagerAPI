namespace PetManager.ErrorHandlers
{
    public class DAPPV_Valid : IErrorHandler
    {
        public APIResponse GetResponse()
        {
            return new APIResponse(APIResponse.ErrorCode.SUCCESS, "DAPPV Vaccine Valid");
        }
    }
}
