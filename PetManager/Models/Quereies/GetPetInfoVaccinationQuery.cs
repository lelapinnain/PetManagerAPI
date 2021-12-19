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

        public override void RunQuery()
        {
            vaccineslist = db.VaccinationViews.Where(w=> w.PetInfoId == petId).ToList();
            
        }

        public override List<VaccinationView> GetResult()
        {
            return vaccineslist;
        }
    }
}

