using E_Commerce.Dal;
using E_Commerce.Dal.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly MainContext MainContext;

        public ProductRepository(MainContext mainContext)
        {
            MainContext = mainContext;
        }

        public async Task<Product?> CreateProductAsync(Product product)
        {
            await MainContext.Products.AddAsync(product);
            await MainContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProductAsync(long productId)
        {
            var product = await GetProductByIdAsync(productId);
            if (product == null)
            {
                throw new Exception("Product not found in DeleteProductAsync");
            }

            MainContext.Products.Remove(product);
            await MainContext.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAllProductsAsync()
        {
            var products = await MainContext.Products.ToListAsync();
            if (products == null)
            {
                throw new Exception("Products not found in GetAllProducts");
            }
            return products;
        }

        public async Task<Product?> GetProductByIdAsync(long productId)
        {
            var product = await MainContext.Products.FindAsync(productId);
            if (product == null)
            {
                throw new Exception("Product not found in GetProductByIdAsync");
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            var products = await MainContext.Products
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToListAsync();
            return products;
        }

        public async Task<Product?> UpdateProductAsync(Product product)
        {
            MainContext.Products.Update(product);
            await MainContext.SaveChangesAsync();
            return product;
        }
    }
}
