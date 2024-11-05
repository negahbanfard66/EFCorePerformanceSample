using EFCorePerformanceTips.CoreLayer.Entities;
using EFCorePerformanceTips.CoreLayer.Interfaces;

namespace EFCorePerformanceTips.ApplicationLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Optimized pagination is now implemented in the repository
        public async Task<List<Product>> GetPaginatedProductsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsAsync(pageNumber, pageSize, cancellationToken);
        }

        public async Task UpdateProductPricesAsync(int categoryId, decimal increaseAmount, CancellationToken cancellationToken)
        {
            await _productRepository.UpdateProductPriceAsync(categoryId, increaseAmount, cancellationToken);
        }

        public async Task<Product> GetProductByIdAsync(int productId, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductByIdAsync(productId, cancellationToken);
        }
    }
}
