using PetManager.Models;
using PetManager.Models.Quereies;

namespace PetManager.DailyVaccines
{
    public class DAPPVDailyVaccines : IDailyVaccines
    {
        public async Task< List<DailyVaccineRecord>> GetDailyVaccines()
        {
            GetDailyDappvQuery getDailyDappvQuery = new GetDailyDappvQuery();
            await getDailyDappvQuery.RunQuery();

            return getDailyDappvQuery.GetResult();
        }
    }
}
