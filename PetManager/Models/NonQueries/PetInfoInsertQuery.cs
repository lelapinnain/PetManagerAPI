using PetManager.DTOs.InputDTOs;

namespace PetManager.Models.NonQueries
{
    public class PetInfoInsertQuery : AbstractNonQuery<String>
    {
        private readonly CoreDbContext db;
        private AddPetInfoInputDTO addPetInfoInputDto;
        private readonly string _url;
        private String response;


       public PetInfoInsertQuery(AddPetInfoInputDTO _addPetInfoInputDto , string url) {

            addPetInfoInputDto = _addPetInfoInputDto;
            _url = url;
            db = new CoreDbContext();

        }
        public override void RunQuery()
        {
            try
            {
                PetInfo petInfo = new PetInfo()
                {
                    PetName = addPetInfoInputDto.PetName,
                    Color = addPetInfoInputDto.Color,
                    Dob = addPetInfoInputDto.Dob,
                    Gender = addPetInfoInputDto.Gender,
                    Images = _url,
                    BuyPrice = addPetInfoInputDto.BuyPrice,
                    Microchip = addPetInfoInputDto.Microchip,
                    Breed = addPetInfoInputDto.Breed,
                };
                db.Add(petInfo);
                db.SaveChanges();

                response = "ok";
            }
            catch (Exception ex )
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
