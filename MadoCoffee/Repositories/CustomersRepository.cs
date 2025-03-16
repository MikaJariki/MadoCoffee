using MadoCoffee.Models;

namespace MadoCoffee.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly AppDbContext _context;
        public CustomersRepository(AppDbContext context)
        {
            _context = context;
        }
        public void CreateCustomer(Customer newCustomer)
        {
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer) 
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(long id)
        {
            return _context.Customers.Find(id);
        }

        public void UpdateCustomer(long id, Customer updateCustomer)
        {
            _context.Customers.Update(updateCustomer);
            _context.SaveChanges();
        }
    }
}
