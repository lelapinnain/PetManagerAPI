namespace PetManager.Models.Quereies
{
    public class GetInvoiceByIDQuery : AbstractQuery<Invoice>
    {
        private readonly CoreDbContext db;
        private int invoiceId;
        private Invoice? invoice;

        public GetInvoiceByIDQuery(int _invoiceId)
        {
            db = new CoreDbContext();
         
            invoiceId = _invoiceId;

            invoice = null;
        }

        public override void RunQuery()
        {
            invoice = db.Invoices.Where(w => w.InvoiceId == invoiceId).FirstOrDefault();
        }

        public override Invoice GetResult()
        {
            return invoice;
        }
    }
}
