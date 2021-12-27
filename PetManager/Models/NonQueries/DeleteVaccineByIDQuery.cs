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

        public override void RunQuery()
        {
            try
            {
                VaccineHistory? vaccine = db.VaccineHistories.Where(v => v.VaccineHistoryId == vaccineId).SingleOrDefault();
                if (vaccine != null)
                {
                    db.Remove(vaccine);
                    db.SaveChanges();
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
           



        }

        public override string GetResult()
        {
            return response;
        }
    }
}
