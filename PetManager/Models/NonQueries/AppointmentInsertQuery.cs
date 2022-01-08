using PetManager.DTOs.InputDTOs;

namespace PetManager.Models.NonQueries
{
    public class AppointmentInsertQuery : AbstractNonQuery<string>
    {
        private readonly CoreDbContext db;
        private AppointmentInputDTO addAppointmentInputDTO;
        private String response;

        public AppointmentInsertQuery(AppointmentInputDTO _addAppointmentInputDTO)
        {
            addAppointmentInputDTO = _addAppointmentInputDTO;
            db = new CoreDbContext();
        }
        public override string GetResult()
        {
           return response;
        }

        public override void RunQuery()
        {
            if (addAppointmentInputDTO != null)
            {

                AppointmentHistory appointmentHistory = new AppointmentHistory()
                {
                    CustomerName = addAppointmentInputDTO.CustomerName,
                    CustomerPhoneNumber = addAppointmentInputDTO.CustomerPhone,
                    Notes = addAppointmentInputDTO.Notes,
                    AppointmentDate = Convert.ToDateTime(addAppointmentInputDTO.AppointmentDate),
                    AppointmentStartTime = Convert.ToDateTime(addAppointmentInputDTO.AppointmentTime),
                    AppointmentDuration = addAppointmentInputDTO.AppointmentDuration,



                };
                db.Add(appointmentHistory);
                db.SaveChanges();
                response = "ok";
            }
         
        }
    }
}
