using System.ComponentModel.DataAnnotations;

namespace PetManager.DTOs.InputDTOs
{
    public class UpdatePetInfoDTO
    {
        public int PetId { get; set; }
        public string PetName { get; set; } = null!;

        [Range(1, 2000)]
        public decimal BuyPrice { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        public string Microchip { get; set; } = null!;
        public string Images { get; set; } = null!;

        [Range(1, 2000)]
        public decimal TransportationPrice { get; set; }

        public string Color { get; set; } = null!;

        public string Gender { get; set; } = null!;
    }
}
