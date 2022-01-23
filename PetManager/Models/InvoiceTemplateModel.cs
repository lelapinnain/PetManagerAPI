namespace PetManager.Models
{
    public class InvoiceTemplateModel
    {
        public Customer Customer { get; set; }

        public PetInfo PetInfo { get; set; }

        public Invoice Invoice { get; set; }
    }
}
