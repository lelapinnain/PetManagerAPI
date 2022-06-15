using Microsoft.EntityFrameworkCore;

namespace PetManager.Models.Quereies
{
    public class GetAllPetInfoQuery : AbstractQuery<List<PetInfo>>
    {
        private readonly CoreDbContext db;
        private List<PetInfo>? petInfoList;

        public GetAllPetInfoQuery()
        {
            db = new CoreDbContext();
            
            petInfoList = null;
        }

        public async override Task<string> RunQuery()
        {
            petInfoList = await db.PetInfos.ToListAsync();
            return ("");
        }

        public override List<PetInfo> GetResult()
        {
            return petInfoList;
        }
    }
}
