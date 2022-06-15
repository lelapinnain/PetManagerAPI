using Microsoft.EntityFrameworkCore;

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

        public async override Task<string> RunQuery()
        {
            AppointmentHistory appointment = await db.AppointmentHistories.Where(a => a.AppointmentId == apptId).SingleOrDefaultAsync();
            if (appointment != null)
            {
                db.Remove(appointment);
               await db.SaveChangesAsync();
                response = "ok";

            }
            else
            {
                response = "Appointment Not Found";
            }
            return response;
        }
    }
}
