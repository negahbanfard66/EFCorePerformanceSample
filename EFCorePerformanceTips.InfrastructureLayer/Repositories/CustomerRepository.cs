using EFCorePerformanceTips.CoreLayer.Entities;
using EFCorePerformanceTips.CoreLayer.Interfaces;
using EFCorePerformanceTips.InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCorePerformanceTips.InfrastructureLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustoemrsWithOrders()
        {
            var custoemrs = await _context.Customers.ToListAsync();

            var customersId = custoemrs.Select(a => a.CustomerId).ToList();

            var orders = _context.Orders.Where(p => customersId.Contains(p.CustomerId));

            foreach (var customer in _context.Customers)
                customer.Orders = await orders.Where(o => o.CustomerId == customer.CustomerId).ToListAsync();

            return custoemrs;
        }
    }

}
