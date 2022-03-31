using System;
using ac_web_test_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ac_web_test_api.AppDbContext
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext()
        {
        }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Employee> employee { get; set; }
        public DbSet<Invoice> invoice { get; set; }
        public DbSet<Company> company { get; set; }
    }
}
