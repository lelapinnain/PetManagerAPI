namespace PetManager.Models.Quereies
{
    public class GetInvoicesAllQuery:AbstractQuery<List<InvoicesListView>>
    {
        private readonly CoreDbContext db;
        private List<InvoicesListView>? invoiceList;

        public GetInvoicesAllQuery()
        {
            db = new CoreDbContext();

            invoiceList = null;
        }

        public override void RunQuery()
        {
            invoiceList = db.InvoicesListViews.ToList();
        }

        public override List<InvoicesListView> GetResult()
        {
            return invoiceList;
        }
    }
}
