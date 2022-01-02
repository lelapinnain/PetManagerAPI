using PetManager.Models;
using PetManager.Models.Quereies;

namespace PetManager.DailyVaccines
{
    public class INTRATRACDailyVaccines : IDailyVaccines
    {
        public List<DailyVaccineRecord> GetDailyVaccines()
        {
            GetDailyIntratracQuery getDailyIntratracQuery = new GetDailyIntratracQuery();
            getDailyIntratracQuery.RunQuery();

            return getDailyIntratracQuery.GetResult();
        }
    }
}
