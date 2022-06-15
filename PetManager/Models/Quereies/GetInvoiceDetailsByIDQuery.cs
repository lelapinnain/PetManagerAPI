using Microsoft.EntityFrameworkCore;

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

        public async override Task<string> RunQuery()
        {
            invoice = await db.InvoiceDetailsViews.Where(x=> x.InvoiceId== invoiceId).FirstOrDefaultAsync();
            return ("");
        }

        public override InvoiceDetailsView GetResult()
        {
            return invoice;
        }
    }
}
