using Microsoft.EntityFrameworkCore;

namespace PetManager.Models.NonQueries
{
    public class DeleteVaccineByIDQuery : AbstractNonQuery<string>
    {
        private readonly CoreDbContext db;
        private int vaccineId;

        private String? response;

        public DeleteVaccineByIDQuery(int _vaccineId)
        {
            vaccineId = _vaccineId;

            db = new CoreDbContext();


        }

        public override async Task<string> RunQuery()
        {
            try
            {
                VaccineHistory? vaccine =await db.VaccineHistories.Where(v => v.VaccineHistoryId == vaccineId).SingleOrDefaultAsync();
                if (vaccine != null)
                {
                    db.Remove(vaccine);
                   await db.SaveChangesAsync();
                    response = "ok";
                }
                else
                {
                    response = "Vaccine Record Not Found";
                }
            }
            catch (Exception ex )
            {

               response=ex.Message;
            }
           return response;



        }

        public override string GetResult()
        {
            return response;
        }
    }
}
