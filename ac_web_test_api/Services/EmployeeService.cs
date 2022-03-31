using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ac_web_test_api.AppDbContext;
using ac_web_test_api.Interfaces;
using ac_web_test_api.Models;
using ac_web_test_api.Responses;
using Microsoft.EntityFrameworkCore;

namespace ac_web_test_api.Services
{
    public class EmployeeService:IEmployee
    {
        private readonly ApiDbContext _context;
        public EmployeeService(ApiDbContext context)
        {
            _context = context;
        }


        public async Task<Employee> AddEmployee(Employee employee)
        {
            
            var newEmployee = new Employee()
            {
                id = employee.id,
                firstName = employee.firstName,
                lastName = employee.lastName,
                age = employee.age,
                companyId = employee.companyId

            };
            await _context.employee.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
           
            return newEmployee;
        }

        public async Task<EmployeeResponse<IEnumerable<Employee>>> GetAllEmployees()
        {
            EmployeeResponse<IEnumerable<Employee>> employeeResponse = new EmployeeResponse<IEnumerable<Employee>>();
            var allEmployees = await _context.employee.AsNoTracking().ToListAsync();
            employeeResponse.employees = allEmployees;
            return employeeResponse;
        }
    }
}
