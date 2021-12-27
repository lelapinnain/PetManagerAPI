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

        public override void RunQuery()
        {

            try
            {
                PetInfo pet = db.PetInfos.Where(pet => pet.PetId == petId).SingleOrDefault();
                if (pet != null)
                {
                    db.Remove(pet);
                    db.SaveChanges();
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




        }

        public override string GetResult()
        {
            return response;
        }
    }
}
