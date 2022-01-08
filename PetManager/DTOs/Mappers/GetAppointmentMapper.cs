using PetManager.DTOs.OutputDTOs;
using PetManager.Models;

namespace PetManager.DTOs.Mappers
{
    public class GetAppointmentMapper : AbstractMapper<List<AppointmentRecord>>
    {
        private List<AppointmentHistory> appointmentHistoriesList;
        private List<AppointmentRecord>? appointmentRecordsList;

        public GetAppointmentMapper(List<AppointmentHistory> _appointmentHistoriesList)
        {
            appointmentHistoriesList = _appointmentHistoriesList;

            appointmentRecordsList = null;
        }
        

        public override List<AppointmentRecord> GetMappedDTO()
        {
            if (appointmentHistoriesList != null)
            {
                appointmentRecordsList = new List<AppointmentRecord>();

                foreach (AppointmentHistory appointmentHistory in appointmentHistoriesList)
                {
                    AppointmentRecord appointmentRecord = new AppointmentRecord();

                    appointmentRecord.AppointmentId = appointmentHistory.AppointmentId;
                    appointmentRecord.CustomerName = appointmentHistory.CustomerName;
                    appointmentRecord.CustomerPhoneNumber = appointmentHistory.CustomerPhoneNumber;
                    appointmentRecord.Notes = appointmentHistory.Notes;
                    appointmentRecord.AppointmentDate = appointmentHistory.AppointmentDate;
                    appointmentRecord.AppointmentStartTime = appointmentHistory.AppointmentStartTime.Value.ToString("HH:mm");
                    appointmentRecord.AppointmentDuration = appointmentHistory.AppointmentDuration.Value;

                    appointmentRecordsList.Add(appointmentRecord);
                }
            }

            return appointmentRecordsList;
        }
    }
}
