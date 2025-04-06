using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WorkshopBookingSystemWebAPI.DTOs;
using WorkshopBookingSystemWebAPI.Interfaces;

namespace WorkshopBookingSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customers
        [HttpGet("Get all Customers")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();

            if (customers == null)
            {
                return NotFound(new { Message = "No customers where found." });
            }

            return Ok(customers);
        }

        // GET: api/Customers/5
        [HttpGet("Get Employee by{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int customerId)
        {
            var customerDto = await _customerService.GetCustomersById(customerId);
            if (customerDto == null)
            {
                return NotFound(new { Message = "No customer found with the provided ID." });
            }
            return Ok(customerDto);
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create new Customer")]
        public async Task<ActionResult> CreateCustomer(CustomerInputDto  customer)
        {
            try 
            {
            var createdCustomer = await _customerService.CreateCustomer(customer);
            return Ok(createdCustomer);
            }
            catch (ValidationException ex)
            {
                var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return BadRequest(errors);
            }
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update Employee information with {customerId}")]
        public async Task<IActionResult> UpdateCustomerInformation(int customerId, CustomerInputDto  customer)
        {
           try
            {
                var updatedCustomer = await _customerService.UpdateCustomer(customerId, customer);
                return Ok(updatedCustomer);
            }
            catch (ValidationException ex)
            {
                var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return BadRequest(errors);
            }
        }

        // DELETE: api/Customers/5
        [HttpDelete("Delete Customer with {customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var deletedCustomer = await _customerService.DeleteCustomer(customerId);

            if (!deletedCustomer)
            {
                return NotFound($"No customer found with ID {customerId}");
            }

            return NoContent();
        }
    }
}
