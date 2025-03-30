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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly MainContext MainContext;

        public PaymentRepository(MainContext mainContext)
        {
            MainContext = mainContext;
        }

        public async Task<Payment?> CreatePaymentAsync(Payment payment)
        {
            await MainContext.Payments.AddAsync(payment);
            await MainContext.SaveChangesAsync();
            return payment;
        }

        public async Task DeletePaymentAsync(long paymentId)
        {
            var payment = await GetPaymentByIdAsync(paymentId);
            MainContext.Payments.Remove(payment);
            await MainContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync(long orderId)
        {
            var payments = await MainContext.Payments
                .Where(p => p.Order != null && p.Order.OrderId == orderId)
                .ToListAsync();
            return payments;
        }

        public async Task<ICollection<Payment>> GetAllPaymentsAsync()
        {
            var payments = await MainContext.Payments.ToListAsync();
            if (payments == null)
            {
                throw new Exception("Payments not found in GetAllPayments");
            }
            return payments;
        }

        public async Task<Payment?> GetPaymentByIdAsync(long paymentId)
        {
            var payment = await MainContext.Payments.FindAsync(paymentId);
            return payment;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByCustomerIdAsync(long customerId)
        {
            var payments = await MainContext.Payments
                .Where(p => p.Order != null && p.Order.CustomerId == customerId)
                .ToListAsync();
            return payments;
        }

        public async Task<Payment?> UpdatePaymentAsync(Payment payment)
        {
            MainContext.Payments.Update(payment);
            await MainContext.SaveChangesAsync();
            return payment;
        }
    }
}
