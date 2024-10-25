using EFCorePerformanceTips.CoreLayer.Entities;

namespace EFCorePerformanceTips.CoreLayer.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken);
        Task AddProductAsync(Product product, CancellationToken cancellationToken);
        Task UpdateProductPriceAsync(int categoryId, decimal increaseAmount, CancellationToken cancellationToken);
    }
}
