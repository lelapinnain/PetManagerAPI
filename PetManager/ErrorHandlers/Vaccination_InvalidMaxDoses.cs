namespace PetManager.ErrorHandlers
{
    public class Vaccination_InvalidMaxDoses : IErrorHandler
    {
        private int maxDoses;

        public Vaccination_InvalidMaxDoses(int _maxDoses)
        {
            maxDoses = _maxDoses;
        }

        public APIResponse GetResponse()
        {
            return new APIResponse(APIResponse.ErrorCode.ERROR_INVALID_VACCINE, "Max number of doses is " + maxDoses.ToString());
        }
    }
}
