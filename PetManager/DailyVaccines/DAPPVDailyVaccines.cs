using PetManager.Models;
using PetManager.Models.Quereies;

namespace PetManager.DailyVaccines
{
    public class DAPPVDailyVaccines : IDailyVaccines
    {
        public List<DailyVaccineRecord> GetDailyVaccines()
        {
            GetDailyDappvQuery getDailyDappvQuery = new GetDailyDappvQuery();
            getDailyDappvQuery.RunQuery();

            return getDailyDappvQuery.GetResult();
        }
    }
}
