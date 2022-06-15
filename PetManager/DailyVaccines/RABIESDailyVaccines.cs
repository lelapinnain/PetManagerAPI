using PetManager.Models;
using PetManager.Models.Quereies;

namespace PetManager.DailyVaccines
{
    public class RABIESDailyVaccines : IDailyVaccines
    {
        public async Task< List<DailyVaccineRecord>> GetDailyVaccines()
        {
            GetDailyRabiesQuery getDailyRabiesQuery = new GetDailyRabiesQuery();
           await getDailyRabiesQuery.RunQuery();

            return getDailyRabiesQuery.GetResult();
        }
    }
}
