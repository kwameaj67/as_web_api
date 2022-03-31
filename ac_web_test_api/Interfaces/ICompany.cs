using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ac_web_test_api.Models;
using ac_web_test_api.Responses;

namespace ac_web_test_api.Interfaces
{
    public interface ICompany
    {
        //Task<CompanyResponse<IEnumerable<Invoice>>> GetAllInvoices();
        //Task<CompanyResponse<IEnumerable<Customer>>> GetAllCustomers();
        //Task<CompanyResponse<IEnumerable<Employee>>> GetAllEmployees();
        Task<IEnumerable<Company>> GetAllData();
        Task<Company>AddCompany(Company company);
    }
}
