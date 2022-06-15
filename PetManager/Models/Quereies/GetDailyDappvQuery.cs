using Microsoft.EntityFrameworkCore;

namespace PetManager.Models.Quereies
{
    public class GetDailyDappvQuery : AbstractQuery<List<DailyVaccineRecord>>
    {
        private readonly CoreDbContext db;
        private List<DappvView>? DappvList;
        private List<DailyVaccineRecord> dailyVaccinesList;

        public GetDailyDappvQuery( )
        {
            db = new CoreDbContext();

            DappvList = null;
            dailyVaccinesList = new List<DailyVaccineRecord>();
        }

        public async override Task<string> RunQuery()
        {   
            DappvList = await db.DappvViews.ToListAsync();

            foreach (var dappvRecord in DappvList)
            {
                DailyVaccineRecord dailyVaccineRecord = new DailyVaccineRecord();
                
                dailyVaccineRecord.PetId = dappvRecord.PetId;
                dailyVaccineRecord.PetName = dappvRecord.PetName;
                dailyVaccineRecord.Dob = dappvRecord.Dob;
                dailyVaccineRecord.Microchip = dappvRecord.Microchip;

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
