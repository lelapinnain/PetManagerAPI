namespace PetManager.ErrorHandlers
{
    public class Vaccination_InvalidBirthdateSpan : IErrorHandler
    {
        private int ageInWeeks;

        public Vaccination_InvalidBirthdateSpan(int _ageInWeeks)
        {
            ageInWeeks = _ageInWeeks;
        }
        public APIResponse GetResponse()
        {
            return new APIResponse(APIResponse.ErrorCode.ERROR_INVALID_VACCINE, "Puppy's age has to be at least "+ageInWeeks+" weeks");
        }
    }
}
