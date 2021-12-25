namespace PetManager.ErrorHandlers
{
    public class Vaccination_Valid : IErrorHandler
    {
        public APIResponse GetResponse()
        {
            return new APIResponse(APIResponse.ErrorCode.SUCCESS, "Vaccine Valid");
        }
    }
}
