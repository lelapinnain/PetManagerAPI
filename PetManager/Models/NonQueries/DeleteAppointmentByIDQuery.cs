namespace PetManager.Models.NonQueries
{
    public class DeleteAppointmentByIDQuery : AbstractNonQuery<string>
    {

        private readonly CoreDbContext db;
        private int apptId;

        private String response;

        public DeleteAppointmentByIDQuery(int _apptId)
        {
            apptId = _apptId;

            db = new CoreDbContext();


        }
        public override string GetResult()
        {
            return response;
        }

        public override void RunQuery()
        {
            AppointmentHistory appointment = db.AppointmentHistories.Where(a => a.AppointmentId == apptId).SingleOrDefault();
            if (appointment != null)
            {
                db.Remove(appointment);
                db.SaveChanges();
                response = "ok";

            }
            else
            {
                response = "Appointment Not Found";
            }
        }
    }
}
