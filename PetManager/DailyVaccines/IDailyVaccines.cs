using PetManager.Models;

namespace PetManager.DailyVaccines
{
    public interface IDailyVaccines
    {
        Task<List<DailyVaccineRecord>> GetDailyVaccines();
    }
}
