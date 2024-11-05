using EFCorePerformanceTips.CoreLayer.Entities;
using EFCorePerformanceTips.CoreLayer.Interfaces;
using EFCorePerformanceTips.InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCorePerformanceTips.InfrastructureLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Products.AsNoTracking() // AsNoTracking
                .Include(p => p.Category) // Eager Loading
                .Skip((pageNumber - 1) * pageSize) // Optimized Pagination 11
                .Take(pageSize) //from 11 to 20
                .ToListAsync(cancellationToken);
        }

        // 3. Compiled Query
        private static readonly Func<ApplicationDbContext, int, CancellationToken, Task<Product>> _compiledGetByIdQuery =
            EF.CompileAsyncQuery((ApplicationDbContext ctx, int id, CancellationToken cancellationToken) =>
                ctx.Products.AsNoTracking().FirstOrDefault(p => p.Id == id));

        public async Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _compiledGetByIdQuery(_context, id, cancellationToken);
        }

        // 5. Batching with ExecuteSqlRaw
        public async Task UpdateProductPriceAsync(int categoryId, decimal increaseAmount, CancellationToken cancellationToken)
        {
            await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ExecuteUpdateAsync(p => p.SetProperty(p => p.Price, p => p.Price + increaseAmount), cancellationToken);
        }

        // Add Product Method
        public async Task AddProductAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Customer>> GetProductsWithCategoriesAsync()
        {
            var custoemrs = await _context.Customers.ToListAsync();

            var customersId = custoemrs.Select(a=> a.CustomerId).ToList();

            var orders =  _context.Orders.Where(p=> customersId.Contains(p.CustomerId));

            foreach(var customer in _context.Customers)
                customer.Orders = orders.Where(o=> o.CustomerId == customer.CustomerId).ToList();

            return custoemrs;
        }
    }

}
