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
    public class CustomerService: ICustomer
    {
        private readonly ApiDbContext _context;
        public CustomerService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var newCustomer = new Customer()
            {
                id = customer.id,
                address = customer.address,
                corpName = customer.corpName,
                companyId = customer.companyId
            };
            await _context.customer.AddAsync(newCustomer);
            await _context.SaveChangesAsync(); 

            return newCustomer;
        }

        public async Task<CustomerResponse<IEnumerable<Customer>>> GetAllCustomers()
        {
            CustomerResponse<IEnumerable<Customer>> customerResponse = new CustomerResponse<IEnumerable<Customer>>();
            var allCustomers = await _context.customer.AsNoTracking().ToListAsync();
            customerResponse.customers = allCustomers;
            return customerResponse;
        }
    }
}
