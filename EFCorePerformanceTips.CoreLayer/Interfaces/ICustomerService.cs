using EFCorePerformanceTips.CoreLayer.Entities;

namespace EFCorePerformanceTips.CoreLayer.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomersWithOrders();
    }
}
