using E_Commerce.Dal.Entites;

namespace E_Commerce.Bll.Services
{
    public interface IPaymentService
    {
        Task<Payment?> CreatePaymentAsync(Payment payment);
        Task<Payment?> UpdatePaymentAsync(Payment payment);
        Task<Payment?> GetPaymentByIdAsync(long paymentId);
        Task DeletePaymentAsync(long paymentId);
        Task<IEnumerable<Payment>> GetPaymentsByCustomerIdAsync(long customerId);
        Task<IEnumerable<Payment>> GetAllPaymentsAsync(long orderId);
    }
}