using Microsoft.EntityFrameworkCore;

namespace PetManager.Models.NonQueries
{
    public class DeletePetInfoByIDQuery : AbstractNonQuery<String>
    {
        private readonly CoreDbContext db;
        private int petId;

        private String response;

        public DeletePetInfoByIDQuery(int _petId)
        {
            petId = _petId;

            db = new CoreDbContext();


        }

        public override async Task<string> RunQuery()
        {

            try
            {
                PetInfo pet = await db.PetInfos.Where(pet => pet.PetId == petId).SingleOrDefaultAsync();
                var vaccines = await db.VaccineHistories.Where(x=> x.PetInfoId == petId).ToListAsync();
                if (pet != null)
                {
                    if(vaccines != null)
                    {
                        db.RemoveRange(vaccines);
                    }
                    db.Remove(pet);
                    await db.SaveChangesAsync();
                    response = "ok";

                }
                else
                {
                    response = "PetInfo Not Found";
                }
            }
            catch (Exception ex)
            {

                response = ex.Message;
            }

            return response;


        }

        public override string GetResult()
        {
            return response;
        }
    }
}
