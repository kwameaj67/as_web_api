using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ac_web_test_api.AppDbContext;
using ac_web_test_api.Interfaces;
using ac_web_test_api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace ac_web_test_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            // add cors
            services.AddCors(c => {
                c.AddPolicy("Policy", options => {
                    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            // Json Serializer
            services.AddControllersWithViews( c => { c.EnableEndpointRouting = false; })
            .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddControllers();

            // connectionStrings
            string  connectionString = Configuration.GetConnectionString("default");
            services.AddDbContext<ApiDbContext>(options => options.UseNpgsql(connectionString));

            // add services
            services.AddScoped<ICustomer, CustomerService>();
            services.AddScoped<IEmployee, EmployeeService>();
            services.AddScoped<IInvoice, InvoiceService>();
            services.AddScoped<ICompany, CompanyService>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // use cors
            app.UseCors(options =>
            {
                options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
