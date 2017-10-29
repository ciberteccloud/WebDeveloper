using Cibertec.Repositories.Northwind;

namespace Cibertec.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
    }
}
