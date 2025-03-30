using E_Commerce.Dal.Entites;
using E_Commerce.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Bll.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository OrderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            OrderRepository = orderRepository;
        }

        public async Task<Order?> CreateOrderAsync(Order order)
        {
            if (order is null)
            {
                throw new Exception("order not found is CreateOrderAsync");
            }
            return await OrderRepository.CreateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(long orderId)
        {
            if (orderId <= 0)
            {
                throw new Exception("order not found is DeleteOrderAsync");
            }
            await OrderRepository.DeleteOrderAsync(orderId);
        }

        public async Task<ICollection<Order>> GetAllOrdersAsync()
        {
            return await OrderRepository.GetAllOrdersAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(long orderId)
        {
            if (orderId <= 0)
            {
                throw new Exception("order not found is GetOrderByIdAsync");
            }
            return await OrderRepository.GetOrderByIdAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(long customerId)
        {
            if (customerId <= 0)
            {
                throw new Exception("order not found is GetOrdersByCustomerIdAsync");
            }
            return await OrderRepository.GetOrdersByCustomerIdAsync(customerId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
        {
            if (status is null)
            {
                throw new Exception("order not found is GetOrdersByStatusAsync");
            }
            return await OrderRepository.GetOrdersByStatusAsync(status);
        }

        public async Task<Order?> UpdateOrderAsync(Order order)
        {
            if (order is null)
            {
                throw new Exception("order not found is UpdateOrderAsync");
            }
            return await OrderRepository.UpdateOrderAsync(order);
        }
    }
}
