using Microsoft.EntityFrameworkCore;

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

        public async override Task<string> RunQuery()
        {
            petInfo = await db.PetInfos.Where(pet => pet.PetId == petId).SingleOrDefaultAsync();
            return ("");
        }

        public override PetInfo GetResult()
        {
            return petInfo;
        }
    }
}
