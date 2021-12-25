namespace PetManager.ErrorHandlers
{
    public class APIResponse
    {
        public enum ErrorCode
        {
            SUCCESS = 100,
            ERROR_INVALID_VACCINE = 200,

            ERROR_NOT_SET = 999
        }

        public ErrorCode Code { get; }
        public string Message { get; }

        public APIResponse()
        {
            Code = ErrorCode.ERROR_NOT_SET;
            Message = string.Empty;
        }

        public APIResponse(ErrorCode _code, string _message)
        {
            Code = _code;
            Message = _message;
        }
    }
}
