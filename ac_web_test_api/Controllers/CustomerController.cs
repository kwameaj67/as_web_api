using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ac_web_test_api.Interfaces;
using ac_web_test_api.Models;
using Microsoft.AspNetCore.Mvc;


namespace ac_web_test_api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }
        // Customers
        // POST: api/customer/addCustomer
        [HttpPost("addCustomer")]
        public async Task<ActionResult<IEnumerable<Customer>>> AddCustomer([FromBody] Customer customer)
        {
            if (customer == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           var newCustomer = await _customer.AddCustomer(customer);
            return Created("", newCustomer);
        }
        // GET: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCustomers()
        {
            var data = await _customer.GetAllCustomers();
            return Ok(data);
        }

    }
}
