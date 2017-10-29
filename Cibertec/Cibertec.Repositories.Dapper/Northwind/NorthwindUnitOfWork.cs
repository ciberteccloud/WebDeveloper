using Cibertec.UnitOfWork;
using Cibertec.Repositories.Northwind;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public NorthwindUnitOfWork(string connectionString)
        {
            Customers = new CustomerRepository(connectionString);            
        }

        public ICustomerRepository Customers { get; private set; }
        
    }
}
