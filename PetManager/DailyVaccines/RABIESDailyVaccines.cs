using PetManager.Models;
using PetManager.Models.Quereies;

namespace PetManager.DailyVaccines
{
    public class RABIESDailyVaccines : IDailyVaccines
    {
        public List<DailyVaccineRecord> GetDailyVaccines()
        {
            GetDailyRabiesQuery getDailyRabiesQuery = new GetDailyRabiesQuery();
            getDailyRabiesQuery.RunQuery();

            return getDailyRabiesQuery.GetResult();
        }
    }
}
