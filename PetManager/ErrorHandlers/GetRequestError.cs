namespace PetManager.ErrorHandlers
{
    public class GetRequestError : IErrorHandler
    {
        private string errorMsg;

        public GetRequestError(string _errorMsg)
        {
            this.errorMsg = _errorMsg;
        }

        public APIResponse GetResponse()
        {
            return new APIResponse(APIResponse.ErrorCode.GET_REQUEST_ERROR, errorMsg);
        }
    }
}
