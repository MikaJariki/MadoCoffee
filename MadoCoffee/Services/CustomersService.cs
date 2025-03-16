using MadoCoffee.DTO;
using MadoCoffee.Models;
using MadoCoffee.Repositories;

namespace MadoCoffee.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;
        public CustomersService(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        public void CreateCustomer(CustomerDto newCustomerDto)
        {
            var customer = new Customer
            {
                FullName = newCustomerDto.FullName,
                PhoneNo = newCustomerDto.PhoneNo,
                Email = newCustomerDto.Email,
                Address = newCustomerDto.Address,
                Gender = newCustomerDto.Gender,
                Note = newCustomerDto.Note
            };
            _customersRepository.CreateCustomer(customer);
        }

        public void DeleteCustomer(long id)
        {
            var customer = _customersRepository.GetCustomerById(id);
            if (customer != null)
            {
                _customersRepository.DeleteCustomer(customer);
            }
        }

        public List<CustomerDto> GetAllCustomers()
        {
            var customers = _customersRepository.GetAllCustomers();
            var customerDtos = new List<CustomerDto>();

            foreach (var customer in customers)
            {
                customerDtos.Add(new CustomerDto
                {
                    ID = customer.ID,
                    FullName = customer.FullName,
                    PhoneNo = customer.PhoneNo,
                    Email = customer.Email,
                    Address = customer.Address,
                    Gender = customer.Gender,
                    Note = customer.Note
                });
            }

            return customerDtos;
        }

        public CustomerDto GetCustomerById(long id)
        {
            var customer = _customersRepository.GetCustomerById(id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            return new CustomerDto
            {
                ID = customer.ID,
                FullName = customer.FullName,
                PhoneNo = customer.PhoneNo,
                Email = customer.Email,
                Address = customer.Address,
                Gender = customer.Gender,
                Note = customer.Note
            };
        }

        public void UpdateCustomer(long id, CustomerDto updateCustomerDto)
        {
            var existCustomer = _customersRepository.GetCustomerById(id);
            if (existCustomer != null)
            {
                existCustomer.FullName = updateCustomerDto.FullName;
                existCustomer.PhoneNo = updateCustomerDto.PhoneNo;
                existCustomer.Email= updateCustomerDto.Email;
                existCustomer.Address = updateCustomerDto.Address;
                existCustomer.Gender = updateCustomerDto.Gender;
                existCustomer.Note = updateCustomerDto.Note;

                _customersRepository.UpdateCustomer(id, existCustomer);
            }
        }
    }
}
