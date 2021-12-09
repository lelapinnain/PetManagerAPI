namespace PetManager.Models.Quereies
{
    public class GetPetInfoByIDQuery : AbstractQuery<PetInfo>
    {
        private readonly CoreDbContext db;
        private int petId;
        private PetInfo? petInfo;

        public GetPetInfoByIDQuery(int _petId)
        {
            petId = _petId;

            db = new CoreDbContext();
            
            petInfo = null;
        }

        public override void RunQuery()
        {
            petInfo = db.PetInfos.Where(pet => pet.PetId == petId).SingleOrDefault();
        }

        public override PetInfo GetResult()
        {
            return petInfo;
        }
    }
}
