using Microsoft.AspNetCore.Mvc;
using MadoCoffee.Services;
using MadoCoffee.DTO;

namespace MadoCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        // GET: api/GetAllCustomers
        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            var customers = _customersService.GetAllCustomers();
            return Ok(customers);
        }

        // GET: api/GetCustomerById/5
        [HttpGet("GetCustomerById/{id}")]
        public IActionResult GetCustomerById(long id)
        {
            var customer = _customersService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound(new { message = "Customer not found!" });
            }
            return Ok(customer);
        }

        // PUT: api/UpdateCustomer/5
        [HttpPut("UpdateCustomer/{id}")]
        public IActionResult UpdateCustomer(long id, [FromBody] CustomerDto updateCustomerDto)
        {
            if (updateCustomerDto == null)
            {
                return BadRequest(new { message = "Invalid customer data!" });
            }

            try
            {
                _customersService.UpdateCustomer(id, updateCustomerDto);
                return Ok(new { message = "Customer updated successfully!" });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/CreateCustomer
        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer([FromBody] CustomerDto newCustomerDto)
        {
            if (newCustomerDto == null)
            {
                return BadRequest(new { message = "Invalid customer data!" });
            }

            _customersService.CreateCustomer(newCustomerDto);
            return Ok(new { message = "Customer created successfully!" });
        }

        // DELETE: api/Customers/5
        [HttpDelete("DeleteCustomer/{id}")]
        public IActionResult DeleteCustomer(long id)
        {
            try
            {
                _customersService.DeleteCustomer(id);
                return Ok(new { message = "Customer deleted successfully!" });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
