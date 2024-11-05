using EFCorePerformanceTips.CoreLayer.Entities;

namespace EFCorePerformanceTips.CoreLayer.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustoemrsWithOrders();
    }
}
