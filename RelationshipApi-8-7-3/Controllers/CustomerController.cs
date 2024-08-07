using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelationshipApi_8_7_3.Models.Dto;
using RelationshipApi_8_7_3.Repository;

namespace RelationshipApi_8_7_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //GET - CustomerCar Details
        [HttpGet("CustomerCar")]
        public async Task<IActionResult> GetCustomerCars()
        {
            var customer = await _customerRepository.GetCustomerCarDetailsAsync();
            return Ok(customer);
        }

        // GET - Customer Details By Id
        [HttpPut]
        public async Task<IActionResult> GetCustomerDetailsById(int id)
        {
            var customer = await _customerRepository.GetCustomerCarDetailsByIdAsync(id);
            return Ok(customer);
        }

        // POST - Add New Customer With Car Details
        [HttpPost("AddNewCustomerWithCar")]
        public async Task<IActionResult> AddNewCustomerWithCar(AddCustomerCarDto dto)
        {
            if (dto != null)
            {
                await _customerRepository.AddCustomerCarDetails(dto);
                return Ok();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id, [FromBody] UpdateCustomerCarDto dto)
        {
            try
            {
                await _customerRepository.UpdateCustomerCarByIdAsync(id, dto);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

    }
}
