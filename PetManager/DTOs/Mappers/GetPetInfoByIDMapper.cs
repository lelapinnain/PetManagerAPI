using PetManager.DTOs.OutputDTOs;
using PetManager.Models;

namespace PetManager.DTOs.Mappers
{
    public class GetPetInfoByIDMapper : AbstractMapper<GetPetInfoOutputDTO>
    {
        private PetInfo petInfo;
        private List<VaccinationView> vaccinations;
        private GetPetInfoOutputDTO? getPetInfoOutput;

        public GetPetInfoByIDMapper(PetInfo _petInfo, List<VaccinationView> _vaccinations)
        {
            petInfo = _petInfo;
            vaccinations = _vaccinations;    

            getPetInfoOutput = null;
        }

        public override GetPetInfoOutputDTO GetMappedDTO()
        {
            if (petInfo != null)
            {
                getPetInfoOutput = new GetPetInfoOutputDTO();

                getPetInfoOutput.PetName = petInfo.PetName;
                getPetInfoOutput.BuyPrice = petInfo.BuyPrice;
                getPetInfoOutput.BreedId = petInfo.BreedId;
                getPetInfoOutput.Dob = petInfo.Dob;
                getPetInfoOutput.Microchip = petInfo.Microchip;
                getPetInfoOutput.Images = petInfo.Images;
                getPetInfoOutput.TransportationPrice = petInfo.TransportationPrice;
                getPetInfoOutput.Gender = petInfo.Gender;
                getPetInfoOutput.Color = petInfo.Color; 
                getPetInfoOutput.Vaccinations = vaccinations;
            }

            return getPetInfoOutput;
        }
    }
}
