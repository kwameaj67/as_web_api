using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ac_web_test_api.Interfaces;
using ac_web_test_api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ac_web_test_api.Controllers
{
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoice _invoice;
        public InvoiceController(IInvoice invoice)
        {
            _invoice = invoice;
        }
        // Invoice
        // POST: api/invoice/addInvoice
        [HttpPost("addInvoice")]
        public async Task<ActionResult<IEnumerable<Invoice>>> AddInvoice([FromBody]Invoice invoice)
        {
            if (invoice == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var newInvoice = await _invoice.AddInvoice(invoice);
            return Created("", newInvoice);
        }
        // GET: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            var data = await _invoice.GetAllInvoices();
            return Ok(data);
        }
    }
}
