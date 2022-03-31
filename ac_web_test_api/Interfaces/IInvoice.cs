using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ac_web_test_api.Models;
using ac_web_test_api.Responses;

namespace ac_web_test_api.Interfaces
{
    public interface IInvoice
    {
        Task<InvoiceResponse<IEnumerable<Invoice>>> GetAllInvoices();
        Task<Invoice> AddInvoice(Invoice invoice);
    } 
}
