using E_Commerce.Dal.Entites;
using E_Commerce.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Bll.Services
{
    public class PaymentService : IPaymentService
    {
       private readonly IPaymentRepository PaymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            PaymentRepository = paymentRepository;
        }

        public async Task<Payment?> CreatePaymentAsync(Payment payment)
        {

            var paymentById = await GetPaymentByIdAsync(payment.PaymentId);

            if (paymentById != null)
            {
                throw new Exception("payment already exists is CreatePaymentAsync");
            }

            return await PaymentRepository.CreatePaymentAsync(payment);
        }

        public async Task DeletePaymentAsync(long paymentId)
        {
            var payment = await GetPaymentByIdAsync(paymentId);

            if (payment != null)
            {
                throw new Exception("payment not found is DeletePaymentAsync");
            }

            await PaymentRepository.DeletePaymentAsync(paymentId);
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync(long orderId)
        {
            var payments = await PaymentRepository.GetAllPaymentsAsync(orderId);
            return payments;
        }

        public async Task<Payment?> GetPaymentByIdAsync(long paymentId)
        {
            if (paymentId <= 0)
            {
                throw new Exception("payment not found is GetPaymentByIdAsync");
            }
            return await PaymentRepository.GetPaymentByIdAsync(paymentId);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByCustomerIdAsync(long customerId)
        {
            var payments = await PaymentRepository.GetPaymentsByCustomerIdAsync(customerId);
            return payments;
        }

        public async Task<Payment?> UpdatePaymentAsync(Payment payment)
        {
            var paymentById = await GetPaymentByIdAsync(payment.PaymentId);
            if (paymentById == null)
            {
                throw new Exception("payment not found is UpdatePaymentAsync");
            }
            return await PaymentRepository.UpdatePaymentAsync(payment);
        }
    }
}
