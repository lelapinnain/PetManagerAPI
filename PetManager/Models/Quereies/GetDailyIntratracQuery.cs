using Microsoft.EntityFrameworkCore;

namespace PetManager.Models.Quereies
{
    public class GetDailyIntratracQuery : AbstractQuery<List<DailyVaccineRecord>>
    {
        private readonly CoreDbContext db;
        private List<IntratracView>? IntratracList;
        private List<DailyVaccineRecord> dailyVaccinesList;

        public GetDailyIntratracQuery( )
        {
            db = new CoreDbContext();

            IntratracList = null;
            dailyVaccinesList = new List<DailyVaccineRecord>();
        }

        public async override Task<string> RunQuery()
        {
            IntratracList = await db.IntratracViews.ToListAsync();

            foreach (var intratracRecord in IntratracList)
            {
                DailyVaccineRecord dailyVaccineRecord = new DailyVaccineRecord();

                dailyVaccineRecord.PetId = intratracRecord.PetId;
                dailyVaccineRecord.PetName = intratracRecord.PetName;
                dailyVaccineRecord.Dob = intratracRecord.Dob;
                dailyVaccineRecord.Microchip = intratracRecord.Microchip;

                dailyVaccinesList.Add(dailyVaccineRecord);
            }
            return ("");
        }

        public override List<DailyVaccineRecord> GetResult()
        {
            return dailyVaccinesList;
        }
    }
}
