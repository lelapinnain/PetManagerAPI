namespace PetManager.Models.Quereies
{
    public class GetCustomerInfoByIDQuery : AbstractQuery<Customer>
    {
        private readonly CoreDbContext db;
        private int customerId;
        private Customer? customer;

        public GetCustomerInfoByIDQuery(int _customerId)
        {
            customerId = _customerId;

            db = new CoreDbContext();
            
            customer = null;
        }

        public override void RunQuery()
        {
            customer = db.Customers.Where(w => w.CustomerId == customerId).SingleOrDefault();
        }

        public override Customer GetResult()
        {
            return customer;
        }
    }
}
