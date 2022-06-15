using PetManager.Models;
using PetManager.Models.Quereies;

namespace PetManager.DailyVaccines
{
    public class INTRATRACDailyVaccines : IDailyVaccines
    {
        public async Task<List<DailyVaccineRecord>> GetDailyVaccines()
        {
            GetDailyIntratracQuery getDailyIntratracQuery = new GetDailyIntratracQuery();
            await getDailyIntratracQuery.RunQuery();

            return getDailyIntratracQuery.GetResult();
        }
    }
}
