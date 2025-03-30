using E_Commerce.Dal.Entites;
using E_Commerce.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Bll.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository ProductRepository;

        public ProductService(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public async Task<Product?> CreateProductAsync(Product product)
        {
            if (product is null)
            {
                throw new Exception("product not found is CreateProductAsync");
            }

            var productExist = await ProductRepository.GetProductByIdAsync(product.ProductId);
           
            if (productExist != null )
            {
                throw new Exception("product already exists is CreateProductAsync");
            }
            return await ProductRepository.CreateProductAsync(product);
        }

        public async Task DeleteProductAsync(long productId)
        {
            var product = await GetProductByIdAsync(productId);
            if (product == null || productId <=0)
            {
                throw new Exception("product not found is DeleteProductAsync");
            }
            await ProductRepository.DeleteProductAsync(productId);
        }

        public async Task<ICollection<Product>> GetAllProductsAsync()
        {
            return await ProductRepository.GetAllProductsAsync();
        }

        public async Task<Product?> GetProductByIdAsync(long productId)
        {
            if (productId <= 0)
            {
                throw new Exception("product not found is GetProductByIdAsync");
            }
            return await ProductRepository.GetProductByIdAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            if (minPrice < 0 || maxPrice < 0)
            {
                throw new Exception("product not found is GetProductsByPriceRangeAsync");
            }
            return await ProductRepository.GetProductsByPriceRangeAsync(minPrice, maxPrice);
        }

        public async Task<Product?> UpdateProductAsync(Product product)
        {
            if (product is null)
            {
                throw new Exception("product not found is UpdateProductAsync");
            }
            var productExist = await ProductRepository.GetProductByIdAsync(product.ProductId);
            if (productExist == null)
            {
                throw new Exception("product not found is UpdateProductAsync");
            }
            return await ProductRepository.UpdateProductAsync(product);
        }
    }
}
