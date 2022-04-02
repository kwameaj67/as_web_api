using System;
using System.IO;
using ac_web_test_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("default");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }

    
}
