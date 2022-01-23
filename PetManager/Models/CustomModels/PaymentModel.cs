namespace PetManager.Models.CustomModels
{
    public class PaymentModel
    {
        public decimal ActualPrice { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal RegistrationFees { get; set; }

        public decimal PriceAfterDiscount { get; set; }

        public int PaymentMethod { get; set; }

        public DateTime PickupDate { get; set; }

        public decimal DepositAmount { get; set; }

        public decimal Tax { get; set; }

        public decimal PriceAfterTax { get; set; }

        public decimal RemaningBalance { get; set; }
    }
}
