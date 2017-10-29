using Cibertec.Models;
using Cibertec.Repositories.Northwind;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {
        }        
    }
}
