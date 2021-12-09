using PetManager.DTOs.InputDTOs;

namespace PetManager.Models.NonQueries
{
    public class PetInfoInsert : AbstractNonQuery<String>
    {
        private readonly CoreDbContext db;
        private AddPetInfoInputDTO addPetInfoInputDto;
        private String response;

       public PetInfoInsert(AddPetInfoInputDTO _addPetInfoInputDto) {
            addPetInfoInputDto = _addPetInfoInputDto;
            db = new CoreDbContext();
        }
        public override void RunQuery()
        {
         PetInfo petInfo = new PetInfo()
         {
             PetName = addPetInfoInputDto.PetName,
             Color = addPetInfoInputDto.Color,
             Dob = addPetInfoInputDto.Dob,
             Gender = addPetInfoInputDto.Gender, 
             Images = addPetInfoInputDto.Images,
             BuyPrice = addPetInfoInputDto.BuyPrice,
             Microchip = addPetInfoInputDto.Microchip,
         };
            db.Add(petInfo);
            db.SaveChanges();
            response = "ok";
        }
        public override string GetResult()
        {
           return response;
        }

     
    }
}
