using Microsoft.EntityFrameworkCore;

namespace PetManager.Models.Quereies
{
    public class GetPetInfoVaccinationQuery:AbstractQuery<List<VaccinationView>>
    {
        private readonly CoreDbContext db;
        private int petId;
        private List<VaccinationView> vaccineslist;

        public GetPetInfoVaccinationQuery(int _petId)
        {
            petId = _petId;

            db = new CoreDbContext();
        }

        public async override Task<string> RunQuery()
        {
            vaccineslist = await db.VaccinationViews.Where(w=> w.PetInfoId == petId).ToListAsync();
            return ("");
            
        }

        public override List<VaccinationView> GetResult()
        {
            return vaccineslist;
        }
    }
}

