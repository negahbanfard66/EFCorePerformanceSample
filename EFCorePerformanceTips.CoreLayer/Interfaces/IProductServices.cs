using EFCorePerformanceTips.CoreLayer.Entities;

namespace EFCorePerformanceTips.CoreLayer.Interfaces
{
    public interface IProductServices
    {
        Task<List<Product>> GetPaginatedProductsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<Product> GetProductByIdAsync(int productId, CancellationToken cancellationToken);
        Task UpdateProductPricesAsync(int categoryId, decimal increaseAmount, CancellationToken cancellationToken);
    }
}
