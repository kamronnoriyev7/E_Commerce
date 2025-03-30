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
    public class OrderRepository : IOrderRepository
    {
        private readonly MainContext MainContext;

        public OrderRepository(MainContext mainContext)
        {
            MainContext = mainContext;
        }

        public async Task<Order?> CreateOrderAsync(Order order)
        {
            await MainContext.Orders.AddAsync(order);
            await MainContext.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(long orderId)
        {
            var order = await GetOrderByIdAsync(orderId);
            MainContext.Orders.Remove(order);
            await MainContext.SaveChangesAsync();
        }

        public async Task<ICollection<Order>> GetAllOrdersAsync()
        {
            var orders = await MainContext.Orders.ToListAsync();
            if (orders == null)
            {
                throw new Exception("Orders not found in GetAllOrders");
            }
            return orders;
        }

        public async Task<Order?> GetOrderByIdAsync(long orderId)
        {
            var order = await MainContext.Orders.FindAsync(orderId);
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(long customerId)
        {
            var orders = await MainContext.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
            return orders;
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
        {
            var orders = await MainContext.Orders.Where(o => o.StatusId == status.StatusId).ToListAsync();
            return orders;
        }

        public async Task<Order?> UpdateOrderAsync(Order order)
        {
            MainContext.Orders.Update(order);
            await MainContext.SaveChangesAsync();
            return order;
        }
    }
}
