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

        public override void RunQuery()
        {
            try
            {
                DewormingHistory? deworming = db.DewormingHistories.Where(v => v.DewormingId == dewormingId).SingleOrDefault();
                if (deworming != null)
                {
                    db.Remove(deworming);
                    db.SaveChanges();
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
        }
    }
}
