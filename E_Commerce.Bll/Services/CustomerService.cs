using E_Commerce.Dal.Entites;
using E_Commerce.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Bll.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository CustomerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        public async Task<Customer?> CreateCustomerAsync(Customer customer)
        {
            if (customer is null)
            {
                throw new Exception("customer not found is AddCustomerAsync");
            }
            return await CustomerRepository.CreateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(long customerId)
        {
            if (customerId <= 0)
            {
                throw new Exception("customer not found is DeleteCustomerAsync");
            }
            await CustomerRepository.DeleteCustomerAsync(customerId);
        }

        public async Task<ICollection<Customer>> GetAllCustomers()
        {
            return await CustomerRepository.GetAllCustomers();
        }

        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("customer not found is GetCustomerByEmailAsync");
            }
            return await CustomerRepository.GetCustomerByEmailAsync(email);
        }

        public async Task<Customer?> GetCustomerByIdAsync(long customerId)
        {
            if (customerId <= 0)
            {
                throw new Exception("customer not found is GetCustomerByIdAsync");
            }
            return await CustomerRepository.GetCustomerByIdAsync(customerId);
        }

        public async Task<Customer?> GetCustomerByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("customer not found is GetCustomerByNameAsync");
            }
            return await CustomerRepository.GetCustomerByNameAsync(name);
        }

        public async Task<Customer?> UpdateCustomerAsync(Customer customer)
        {
            if (customer is null)
            {
                throw new Exception("customer not found is UpdateCustomerAsync");
            }
            return await CustomerRepository.UpdateCustomerAsync(customer);
        }
    }
}
