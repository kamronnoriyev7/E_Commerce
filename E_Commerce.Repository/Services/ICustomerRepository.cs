using E_Commerce.Dal.Entites;

namespace E_Commerce.Repository.Services;

public interface ICustomerRepository
{
    Task<Customer?> CreateCustomerAsync(Customer customer);
    Task<Customer?> UpdateCustomerAsync(Customer customer);
    Task<Customer?> GetCustomerByIdAsync(long customerId);
    Task DeleteCustomerAsync(long customerId);
    Task<Customer?> GetCustomerByNameAsync(string name);
    Task<Customer?> GetCustomerByEmailAsync(string email);
    Task<ICollection<Customer>> GetAllCustomers();
}