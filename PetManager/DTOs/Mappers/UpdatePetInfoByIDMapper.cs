using PetManager.DTOs.InputDTOs;
using PetManager.DTOs.OutputDTOs;
using PetManager.Models;

namespace PetManager.DTOs.Mappers
{
    public class UpdatePetInfoByIDMapper:AbstractMapper<UpdatePetInfoDTO>
    {
        private PetInfo petInfo;
        private UpdatePetInfoDTO? updatePetInfoDTO;

        public UpdatePetInfoByIDMapper(PetInfo _petInfo)
        {
            petInfo = _petInfo;

            updatePetInfoDTO = null;
        }

        public override UpdatePetInfoDTO GetMappedDTO()
        {
            if (petInfo != null)
            {
                updatePetInfoDTO = new UpdatePetInfoDTO();

                updatePetInfoDTO.PetName = petInfo.PetName;
                updatePetInfoDTO.BuyPrice = petInfo.BuyPrice;
                updatePetInfoDTO.Dob = petInfo.Dob;
                updatePetInfoDTO.Microchip = petInfo.Microchip;
                updatePetInfoDTO.Images = petInfo.Images;
                updatePetInfoDTO.TransportationPrice = petInfo.TransportationPrice;
                updatePetInfoDTO.Gender = petInfo.Gender;
                updatePetInfoDTO.Color = petInfo.Color;
            }

            return updatePetInfoDTO;
        }
    }
}
