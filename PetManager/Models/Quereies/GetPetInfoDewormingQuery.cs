using Microsoft.EntityFrameworkCore;

namespace PetManager.Models.Quereies
{
    public class GetPetInfoDewormingQuery : AbstractQuery<List<DewormingView>>
    {
        private readonly CoreDbContext db;
        private int petId;
        private List<DewormingView> dewormingList;

        public GetPetInfoDewormingQuery(int _petId)
        {
            petId = _petId;

            db = new CoreDbContext();
        }
        public override List<DewormingView> GetResult()
        {
            return dewormingList;
        }

        public async override Task<string> RunQuery()
        {
            dewormingList = await db.DewormingViews.Where(w => w.PetInfoId == petId).ToListAsync();
            return ("");
        }
    }
}
