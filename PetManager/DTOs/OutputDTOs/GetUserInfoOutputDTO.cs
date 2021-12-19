using PetManager.Models;

namespace PetManager.DTOs.OutputDTOs
{
    public class GetUserInfoOutputDTO
    {
        public string? Email { get; set; }
       
        public string? FirstName { get; set; }
       
        public string? LastName { get; set; }
        
        public string? token { get; set; }
    }
}
