using Microsoft.EntityFrameworkCore;
using PetManager.Models;

namespace PetManager.Utilities
{
    public class GetVaccineHistoryByTypeAndPet : IUtility<List<VaccineHistory>>
    {
        private readonly CoreDbContext db;
        private List<VaccineHistory> vaccineHistories;
        private int vaccineId;
        private int petId;

        public GetVaccineHistoryByTypeAndPet(int _petId, int _vaccineId)
        {
            petId = _petId;
            vaccineId = _vaccineId;

            db = new CoreDbContext();
            vaccineHistories = new List<VaccineHistory>();
        }

        public async Task<List<VaccineHistory>> Execute()
        {
            vaccineHistories = await db.VaccineHistories.Where(w => w.PetInfoId == petId && w.VaccineId == vaccineId).OrderByDescending(od => od.VaccineDate).ToListAsync();
            return vaccineHistories;
        }
    }
}
