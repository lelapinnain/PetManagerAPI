namespace PetManager.Models.Quereies
{
    public class GetInvoiceDetailsByIDQuery : AbstractQuery<InvoiceDetailsView>
    {
        private readonly CoreDbContext db;
        private int invoiceId;
        private InvoiceDetailsView? invoice;

        public GetInvoiceDetailsByIDQuery(int _invoiceId)
        {
            db = new CoreDbContext();

            invoiceId = _invoiceId;

            invoice = null;
        }

        public override void RunQuery()
        {
            invoice = db.InvoiceDetailsViews.Where(x=> x.InvoiceId== invoiceId).FirstOrDefault();
        }

        public override InvoiceDetailsView GetResult()
        {
            return invoice;
        }
    }
}
