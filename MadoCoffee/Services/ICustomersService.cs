using MadoCoffee.DTO;

namespace MadoCoffee.Services
{
    public interface ICustomersService
    {
        List<CustomerDto> GetAllCustomers();
        CustomerDto GetCustomerById(long id);
        void UpdateCustomer(long id, CustomerDto updateCustomerDto);
        void CreateCustomer(CustomerDto newCustomerDto);
        void DeleteCustomer(long id);
    }
}
