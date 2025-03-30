using E_Commerce.Dal.Entites;

namespace E_Commerce.Bll.Services
{
    public interface IOrderService
    {
        Task<Order?> CreateOrderAsync(Order order);
        Task<Order?> UpdateOrderAsync(Order order);
        Task<Order?> GetOrderByIdAsync(long orderId);
        Task DeleteOrderAsync(long orderId);
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(long customerId);
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
        Task<ICollection<Order>> GetAllOrdersAsync();
    }
}