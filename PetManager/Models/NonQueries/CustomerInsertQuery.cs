using PetManager.Models.CustomModels;

namespace PetManager.Models.NonQueries
{
    public class CustomerInsertQuery : AbstractNonQuery<int>
    {
        private readonly CoreDbContext db;
        private CustomerModel customer;
        private int response;

        public CustomerInsertQuery(CoreDbContext _db, CustomerModel _customer)
        {
            db = _db;
            customer = _customer;
        }

        public override int GetResult()
        {
           return response;
        }

        public override void RunQuery()
        {
            if (customer != null)
            {
                Customer customerDB = new Customer()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    Email = customer.Email,
                    Phone = customer.Phone
                };

                db.Add(customerDB);
                db.SaveChanges();
                response = customerDB.CustomerId;
            }
        }
    }
}
