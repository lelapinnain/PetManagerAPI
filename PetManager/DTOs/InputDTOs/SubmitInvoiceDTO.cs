using PetManager.Models.CustomModels;

namespace PetManager.DTOs.InputDTOs
{
    public class SubmitInvoiceDTO
    {
        public int PetId { get; set; }

        public CustomerModel Customer { get; set; }

        public PaymentModel Payment { get; set; }
    }
}
