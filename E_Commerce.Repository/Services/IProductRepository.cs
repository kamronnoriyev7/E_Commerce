using E_Commerce.Dal.Entites;

namespace E_Commerce.Repository.Services
{
    public interface IProductRepository
    {
        Task<Product?> CreateProductAsync(Product product);
        Task<Product?> UpdateProductAsync(Product product);
        Task<Product?> GetProductByIdAsync(long productId);
        Task DeleteProductAsync(long productId);
        Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<ICollection<Product>> GetAllProductsAsync();
    }
 