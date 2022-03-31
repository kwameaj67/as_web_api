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
    public class CompanyController : Controller
    {
        
        private readonly ICompany _company;
        public CompanyController(ICompany company)
        {
            _company = company;
        }
        // POST: api/company/addCompany
        [HttpPost("addCompany")]
        public async Task<ActionResult<IEnumerable<Company>>> AddCompany([FromBody]Company company)
        {
            if (company == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = await _company.AddCompany(company);
            return Created("",data);
        }
        // GET: api/company/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Company>>> GetAll()
        {
            var data = await _company.GetAllData();
            return Ok(data);
        }


    }
}
