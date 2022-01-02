using PetManager.Models;

namespace PetManager.DailyVaccines
{
    public interface IDailyVaccines
    {
        List<DailyVaccineRecord> GetDailyVaccines();
    }
}
