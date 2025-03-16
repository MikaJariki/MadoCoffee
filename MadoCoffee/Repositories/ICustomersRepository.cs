using MadoCoffee.Models;

namespace MadoCoffee.Repositories
{
    public interface ICustomersRepository
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(long id);
        void UpdateCustomer(long id, Customer updateCustomer);
        void CreateCustomer(Customer newCustomer);
        void DeleteCustomer(Customer customer);
    }
}
