using EFCorePerformanceTips.CoreLayer.Entities;
using EFCorePerformanceTips.CoreLayer.Interfaces;

namespace EFCorePerformanceTips.ApplicationLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetCustomersWithOrders()
        {
            return await _customerRepository.GetCustoemrsWithOrders();
        }
    }
}
