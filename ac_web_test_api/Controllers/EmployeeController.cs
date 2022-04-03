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
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        // Employee
        // POST: api/addEmployee
        [HttpPost("addEmployee")]
        public async Task<ActionResult<IEnumerable<Employee>>> AddCustomers([FromBody]Employee employee)
        {
            if (employee == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
           var newEmployee = await _employee.AddEmployee(employee);
            return Created("", newEmployee);
        }
        // GET: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var data = await _employee.GetAllEmployees();
            return Ok(data);
        }
    }
}
