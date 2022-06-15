using Microsoft.EntityFrameworkCore;

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

        public async override Task<string> RunQuery()
        {
            customer = await db.Customers.Where(w => w.CustomerId == customerId).SingleOrDefaultAsync();
            return ("");
        }

        public override Customer GetResult()
        {
            return customer;
        }
    }
}
