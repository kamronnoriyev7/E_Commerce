using E_Commerce.Dal.Entites;

namespace E_Commerce.Bll.Services;

public interface ICartService
{
    Task AddProductToCartAsync(long customerId, long ProductId, int quantity);
    Task ClearCartAsync(long customerId);
    Task<Cart?> GetCartByCustomerIdAsync(long customerId);
    Task UpdateCartAsync(Cart cart);
    Task DeleteCartAsync(long customerId);
    Task<ICollection<Cart>> GetAllCartsAsync();

}