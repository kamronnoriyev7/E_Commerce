
using E_Commerce.Dal.Entites;
using E_Commerce.Repository.Services;

namespace E_Commerce.Bll.Services;

public class CartService : ICartService
{
    private readonly ICartRepository CartRepository;

    public CartService(ICartRepository cartRepository)
    {
        CartRepository = cartRepository;
    }

    public async Task AddProductToCartAsync(long customerId, long productId, int quantity)
    {
        var cart = await CartRepository.GetCartByCustomerIdAsync(customerId);
        if (cart == null)
        {
            cart = await CartRepository.CreateCartAsync(customerId);
        }

        var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductId == productId);
        if (cartProduct == null)
        {
            cartProduct = new CartProduct
            {
                CartId = cart.CartId,
                ProductId = productId,
                Quantity = quantity
            };
            cart.CartProducts.Add(cartProduct);
        }
        else
        {
            cartProduct.Quantity = quantity;
            cart.CartProducts.Add(cartProduct);
        }
        await CartRepository.UpdateCartAsync(cart);
    }

    public async Task  ClearCartAsync(long customerId)
    {
        var cart = await CartRepository.GetCartByCustomerIdAsync(customerId);
        if (cart == null)
        {
            throw new Exception("Cart not found in ClearCartAsync");
        }
        await CartRepository.ClearCartAsync(customerId);
    }

    public async Task DeleteCartAsync(long customerId)
    {
        var cart = await CartRepository.GetCartByCustomerIdAsync(customerId);
        if (cart == null)
        {
            throw new Exception("Cart not found in DeleteCartAsync");
        }
        await CartRepository.DeleteCartAsync(customerId);
    }

    public async Task<ICollection<Cart>> GetAllCartsAsync()
    {
        return await CartRepository.GetAllCartsAsync();
    }

    public async Task<Cart?> GetCartByCustomerIdAsync(long customerId)
    {
        return await CartRepository.GetCartByCustomerIdAsync(customerId);
    }

    public async Task UpdateCartAsync(Cart cart)
    {
        var existingCart = await CartRepository.GetCartByCustomerIdAsync(cart.CustomerId);
        if (existingCart == null)
        {
            throw new Exception("Cart not found in UpdateCartAsync");
        }
        await CartRepository.UpdateCartAsync(cart);
    }
}
