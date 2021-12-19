using System.Net;

namespace PetManager.DTOs.OutputDTOs
{
    public class ErrorResponse
    {
        public HttpStatusCode code { get; set; }
        public string message { get; set; }

        public ErrorResponse(HttpStatusCode _code, string _message)
        {
            code = _code;
            message = _message;
        }
    }
}
