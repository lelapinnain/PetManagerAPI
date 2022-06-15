using PetManager.Models.CustomModels;

namespace PetManager.Models.NonQueries
{
    public class InvoiceInsertQuery : AbstractNonQuery<int>
    {
        private readonly CoreDbContext db;
        private PaymentModel payment;
        private int response;
        private int customerId;
        private int petId;

        public InvoiceInsertQuery(CoreDbContext _db, PaymentModel _payment, int _customerId, int _petId)
        {
            db = _db;
            payment = _payment;
            customerId = _customerId;
            petId = _petId;
        }

        public override int GetResult()
        {
           return response;
        }

        public override async Task<string> RunQuery()
        {
            if (payment != null)
            {
                Invoice invoice = new Invoice()
                {
                    ActualPrice = payment.ActualPrice,
                    DiscountAmount = payment.DiscountAmount,
                    PriceAfterDiscount = payment.PriceAfterDiscount,
                    RegistrationFees = payment.RegistrationFees,
                    Tax = payment.Tax,
                    PriceAfterTax = payment.PriceAfterTax,
                    DepositAmount = payment.DepositAmount,
                    RemainingBalance = payment.RemaningBalance,
                    DateOfPurchase = DateTime.Now,
                    PickupDate = payment.PickupDate,
                    DepositDate = DateTime.Now,

                    CustomerId = customerId,
                    PetinfoId = petId
                };

                db.Add(invoice);
               await db.SaveChangesAsync();
                response = invoice.InvoiceId;
            }
            return ("");
        }
    }
}
