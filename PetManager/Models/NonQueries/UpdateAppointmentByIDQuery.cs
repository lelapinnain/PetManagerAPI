using Microsoft.EntityFrameworkCore;
using PetManager.DTOs.InputDTOs;

namespace PetManager.Models.NonQueries
{
    public class UpdateAppointmentByIDQuery : AbstractNonQuery<string>
    {
        private readonly CoreDbContext db;
        private AppointmentInputDTO appointmentInputDTO;
        private AppointmentHistory? appointmentHistory;
        private String response;

        public UpdateAppointmentByIDQuery(AppointmentInputDTO _appointmentInputDTO)
        {
            appointmentInputDTO = _appointmentInputDTO;
           

            db = new CoreDbContext();
            appointmentHistory = null;




        }
        public override string GetResult()
        {
            return response;
        }

        public override async Task<string> RunQuery()
        {
            appointmentHistory = await db.AppointmentHistories.Where(a => a.AppointmentId == appointmentInputDTO.ApptId).SingleOrDefaultAsync();
            if (appointmentHistory != null)
            {
                appointmentHistory.CustomerName = appointmentInputDTO.CustomerName;
                appointmentHistory.CustomerPhoneNumber = appointmentInputDTO.CustomerPhone;
                appointmentHistory.AppointmentDate = Convert.ToDateTime( appointmentInputDTO.AppointmentDate);
                appointmentHistory.Notes = appointmentInputDTO.Notes;
                appointmentHistory.AppointmentStartTime = Convert.ToDateTime(appointmentInputDTO.AppointmentTime);
                appointmentHistory.AppointmentDuration = appointmentInputDTO.AppointmentDuration;
                

                db.Update(appointmentHistory);
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
