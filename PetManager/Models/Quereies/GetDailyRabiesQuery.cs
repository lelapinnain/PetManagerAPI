namespace PetManager.Models.Quereies
{
    public class GetDailyRabiesQuery : AbstractQuery<List<DailyVaccineRecord>>
    {
        private readonly CoreDbContext db;
        private List<RabiesView>? RabiesList;
        private List<DailyVaccineRecord> dailyVaccinesList;

        public GetDailyRabiesQuery( )
        {
            db = new CoreDbContext();

            RabiesList = null;
            dailyVaccinesList = new List<DailyVaccineRecord>();
        }

        public override void RunQuery()
        {
            RabiesList = db.RabiesViews.ToList();

            foreach (var rabiesRecord in RabiesList)
            {
                DailyVaccineRecord dailyVaccineRecord = new DailyVaccineRecord();

                dailyVaccineRecord.PetId = rabiesRecord.PetId;
                dailyVaccineRecord.PetName = rabiesRecord.PetName;
                dailyVaccineRecord.Dob = rabiesRecord.Dob;
                dailyVaccineRecord.Microchip = rabiesRecord.Microchip;

                dailyVaccinesList.Add(dailyVaccineRecord);
            }
        }

        public override List<DailyVaccineRecord> GetResult()
        {
            return dailyVaccinesList;
        }
    }
}
