using PetManager.DTOs.OutputDTOs;
using PetManager.Models;

namespace PetManager.DTOs.Mappers
{
    public class GetAllPetInfoMapper : AbstractMapper<List<GetPetInfoOutputDTO>>
    {
        private List<PetInfo> petInfoList;
        private List<GetPetInfoOutputDTO>? getPetInfoOutputList;

        public GetAllPetInfoMapper(List<PetInfo> _petInfoList)
        {
            petInfoList = _petInfoList;

            getPetInfoOutputList = null;
        }

        public override List<GetPetInfoOutputDTO> GetMappedDTO()
        {
            if (petInfoList != null)
            {
                getPetInfoOutputList = new List<GetPetInfoOutputDTO>();

                foreach (PetInfo petInfo in petInfoList)
                {
                    GetPetInfoOutputDTO getPetInfoOutput = new GetPetInfoOutputDTO();
                    getPetInfoOutput.petId = petInfo.PetId;
                    getPetInfoOutput.PetName = petInfo.PetName;
                    getPetInfoOutput.BuyPrice = petInfo.BuyPrice;
                    getPetInfoOutput.BreedId = petInfo.BreedId;
                    getPetInfoOutput.Dob = petInfo.Dob;
                    getPetInfoOutput.Microchip = petInfo.Microchip;
                    getPetInfoOutput.Images = petInfo.Images;
                    getPetInfoOutput.TransportationPrice = petInfo.TransportationPrice;
                    getPetInfoOutput.Gender = petInfo.Gender;
                    getPetInfoOutput.Color = petInfo.Color;

                    getPetInfoOutputList.Add(getPetInfoOutput);
                }
            }

            return getPetInfoOutputList;
        }
    }
}
