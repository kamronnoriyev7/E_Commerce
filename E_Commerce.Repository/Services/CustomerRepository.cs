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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MainContext MainContext;

        public CustomerRepository(MainContext mainContext)
        {
            MainContext = mainContext;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            await MainContext.Customers.AddAsync(customer);
            await MainContext.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(long customerId)
        {
            var customer = await GetCustomerByIdAsync(customerId);
            MainContext.Customers.Remove(customer);
            await MainContext.SaveChangesAsync();
        }

        public async Task<ICollection<Customer>> GetAllCustomers()
        {
            var customers = await MainContext.Customers.ToListAsync();
            if (customers == null)
            {
                throw new Exception("Customers not found in GetAllCustomers");
            }
            return customers;
        }

        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            var customer = await MainContext.Customers.FirstOrDefaultAsync(c => c.Email == email);
            return customer;
        }

        public async Task<Customer?> GetCustomerByIdAsync(long customerId)
        {
            var customer = await MainContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
            return customer;
        }

        public async Task<Customer?> GetCustomerByNameAsync(string name)
        {
            var customer = await MainContext.Customers.FirstOrDefaultAsync(c => c.FirstName == name);
            return customer;
        }

        public async Task<Customer?> UpdateCustomerAsync(Customer customer)
        {
            MainContext.Customers.Update(customer);
            await MainContext.SaveChangesAsync();
            return customer;
        }
    }
}
