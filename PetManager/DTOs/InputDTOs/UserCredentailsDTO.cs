using System.ComponentModel.DataAnnotations;

namespace PetManager.DTOs.InputDTOs
{
    public class UserCredentailsDTO
    {

        public string? FirstName { get; set; } = null!;

        public string? LastName { get; set; } = null!;
       
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
