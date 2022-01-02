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

        public override void RunQuery()
        {   
            DappvList = db.DappvViews.ToList();

            foreach (var dappvRecord in DappvList)
            {
                DailyVaccineRecord dailyVaccineRecord = new DailyVaccineRecord();
                
                dailyVaccineRecord.PetId = dappvRecord.PetId;
                dailyVaccineRecord.PetName = dappvRecord.PetName;
                dailyVaccineRecord.Dob = dappvRecord.Dob;
                dailyVaccineRecord.Microchip = dappvRecord.Microchip;

                dailyVaccinesList.Add(dailyVaccineRecord);
            }
        }

        public override List<DailyVaccineRecord> GetResult()
        {
            return dailyVaccinesList;
        }
    }
}
