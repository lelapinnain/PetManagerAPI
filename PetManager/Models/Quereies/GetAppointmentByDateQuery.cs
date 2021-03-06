using Microsoft.EntityFrameworkCore;
using PetManager.DTOs.InputDTOs;

namespace PetManager.Models.Quereies
{
    public class GetAppointmentByDateQuery : AbstractQuery<List<AppointmentHistory>>
    {
        private readonly CoreDbContext db;
        private DateTime date;
        private List<AppointmentHistory> appointmentHistoryList;

        public GetAppointmentByDateQuery(DateTime _date)
        {
            date = _date;

            db = new CoreDbContext();

            
        }
        public  override List<AppointmentHistory> GetResult()
        {
            return  appointmentHistoryList;
        }

        public async override Task<string> RunQuery()
        {
            appointmentHistoryList = await db.AppointmentHistories.Where(a=> a.AppointmentDate == date).ToListAsync();
            return ("");
        }
    }
}
