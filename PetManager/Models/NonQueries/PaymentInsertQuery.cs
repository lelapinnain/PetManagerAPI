using PetManager.DTOs.InputDTOs;

namespace PetManager.Models.NonQueries
{
    public class PaymentInsertQuery : AbstractNonQuery<string>
    {
        private readonly CoreDbContext db;
        private Invoice invoice;
        private String response;
        private int invoiceId;
        private int paymentMethodId;
        private decimal amount;

        public PaymentInsertQuery(CoreDbContext _db, int _invoiceId, int _paymentMethodId, decimal _amount)
        {
            db = _db;
            invoiceId = _invoiceId;
            paymentMethodId = _paymentMethodId;
            amount = _amount;
        }

        public override string GetResult()
        {
            return response;
        }

        public override async Task<string> RunQuery()
        {
            Payment payment = new Payment()
            {
                InvoiceId = invoiceId,
                PaymentMethodId = paymentMethodId,
                Amount = amount,
                PaymentDate = DateTime.Now
            };

            db.Add(payment);
           await db.SaveChangesAsync();
            response = "ok";
            return response;
        }
    }
}
