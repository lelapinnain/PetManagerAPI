using Microsoft.EntityFrameworkCore;

namespace PetManager.Models.NonQueries
{
    public class DeleteDewormingByIDQuery : AbstractNonQuery<string>
    {
        private readonly CoreDbContext db;
        private int dewormingId;

        private String? response;

        public DeleteDewormingByIDQuery(int _dewormingId)
        {
            dewormingId = _dewormingId;

            db = new CoreDbContext();


        }

        public override string GetResult()
        {
            return response;
        }

        public override async Task<string> RunQuery()
        {
            try
            {
                DewormingHistory? deworming =await db.DewormingHistories.Where(v => v.DewormingHistoryId == dewormingId).SingleOrDefaultAsync();
                if (deworming != null)
                {
                    db.Remove(deworming);
                   await db.SaveChangesAsync();
                    response = "ok";
                }
                else
                {
                    response = "Deworming Record Not Found";
                }
                
            }
            catch (Exception ex)
            {

                response = ex.Message;
            }
            return response;
        }
    }
}
