using Microsoft.EntityFrameworkCore;
using PetManager.DTOs.InputDTOs;

namespace PetManager.Models.NonQueries
{
    public class UpdatePetInfoByIDQuery:AbstractNonQuery<PetInfo>
    {
        private readonly CoreDbContext db;
        private int petId;
        private PetInfo? petInfo;
        private UpdatePetInfoDTO updatePetInfoDTO;
        private String response;

        public UpdatePetInfoByIDQuery(UpdatePetInfoDTO _UpdatePetInfoInputDto)
        {
            petId = _UpdatePetInfoInputDto.PetId;
             updatePetInfoDTO = _UpdatePetInfoInputDto;

            db = new CoreDbContext();

            petInfo = null;

        }

        public override async Task<string> RunQuery()
        {
            try
            {
                petInfo =await db.PetInfos.Where(pet => pet.PetId == petId).SingleOrDefaultAsync();
                if (petInfo != null)
                {
                    petInfo.PetName = updatePetInfoDTO.PetName;
                    petInfo.Color = updatePetInfoDTO.Color;
                    petInfo.Dob = updatePetInfoDTO.Dob;
                    petInfo.BuyPrice = updatePetInfoDTO.BuyPrice;
                    petInfo.Gender = updatePetInfoDTO.Gender;
                    petInfo.Microchip = updatePetInfoDTO.Microchip;
                    petInfo.TransportationPrice = updatePetInfoDTO.TransportationPrice;
                    petInfo.Breed = updatePetInfoDTO.Breed;
                    db.Update(petInfo);
                    await db.SaveChangesAsync();

                }
                else
                {
                       response = "Pet Not Found";
                }
            }
            catch (Exception ex)
            {

                response = ex.Message;
            }
           

            return response;

        }

        public override PetInfo GetResult()
        {
            return (db.PetInfos.Where(pet => pet.PetId == petId).SingleOrDefault());
        }
    }
}

