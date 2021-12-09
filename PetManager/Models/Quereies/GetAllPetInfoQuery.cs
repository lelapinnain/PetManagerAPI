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

        public override void RunQuery()
        {
            petInfoList = db.PetInfos.ToList();
        }

        public override List<PetInfo> GetResult()
        {
            return petInfoList;
        }
    }
}
