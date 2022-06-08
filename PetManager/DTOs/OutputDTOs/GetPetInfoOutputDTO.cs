using PetManager.Models;

namespace PetManager.DTOs.OutputDTOs
{
    public class GetPetInfoOutputDTO
    {
        public int petId { get; set; }
        public string PetName { get; set; } = null!;

        public decimal BuyPrice { get; set; }

        public int BreedId { get; set; }

        public DateTime Dob { get; set; }

        public string Microchip { get; set; } = null!;
        
        public string Images { get; set; } = null!;

        public DateTime ReceiveDate { get; set; }

        public decimal TransportationPrice { get; set; }

        public string Color { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public bool IsSold { get; set; }

        public int? PetTypeId { get; set; }

        public int? BreederId { get; set; }

        public List<VaccinationView>? Vaccinations { get; set; }

        public List<DewormingView>? Deworming { get; set; }
        public string Breed { get; set; }

    }
}
