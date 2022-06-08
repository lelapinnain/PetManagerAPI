using System.ComponentModel.DataAnnotations;

namespace PetManager.DTOs.InputDTOs
{
    public class AddPetInfoInputDTO
    {
        public string PetName { get; set; } = null!;

        [Range(1,2000)]
        public decimal BuyPrice { get; set; }

      [Required]
        public DateTime Dob { get; set; }

        public string Microchip { get; set; } = null!;
        public IFormFile File { get; set; } = null!;
       
        public decimal TransportationPrice { get; set; }

        public string Color { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string Breed { get; set; } = null!;

      
    }
}
