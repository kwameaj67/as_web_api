using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ac_web_test_api.AppDbContext;
using ac_web_test_api.Interfaces;
using ac_web_test_api.Models;
using ac_web_test_api.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ac_web_test_api.Services
{
    public class CompanyService : ICompany
    {
        private readonly ApiDbContext _context;
        public CompanyService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Company> AddCompany(Company company)
        {
            var newCompany = new Company()
            {
                id = company.id,
                name = company.name
                
            };
            await _context.company.AddAsync(newCompany);
            await _context.SaveChangesAsync();
            return newCompany;
        }

        public async Task<IEnumerable<Company>> GetAllData()
        {
            var data = await _context.company
                            .Include(p => p.customers)
                            .Include(p => p.employees)
                            .Include(p => p.invoices)
                            .AsNoTracking()
                            .ToListAsync();
            return data;

        }
    }
}
