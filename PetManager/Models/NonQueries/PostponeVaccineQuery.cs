namespace PetManager.Models.NonQueries
{
    public class PostponeVaccineQuery : AbstractNonQuery<string>
    {
        private readonly CoreDbContext db;
        private int petId ;
        private PetInfo petInfo ;
        private String response;

        public PostponeVaccineQuery(int _petId)
        {
            db = new CoreDbContext();
            petId = _petId;
            

        }
        public override string GetResult()
        {
           return response;
        }

        public override async Task<string> RunQuery()
        {
           
                petInfo = db.PetInfos.Where(pet => pet.PetId == petId).FirstOrDefault();
                if (petInfo != null)
                {
                    petInfo.VaccinePostponed = true;
                    petInfo.VaccinePostponeDate = DateTime.Now.AddDays(7);
                    db.Update(petInfo);
                    await db.SaveChangesAsync();
                response = "ok";
                }
                else
                {
                    response = "Record not found";
                }
           return response;
          
        }
    }
}
