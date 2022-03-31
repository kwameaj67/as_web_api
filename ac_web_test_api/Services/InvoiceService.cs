using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ac_web_test_api.AppDbContext;
using ac_web_test_api.Interfaces;
using ac_web_test_api.Models;
using ac_web_test_api.Responses;
using Microsoft.EntityFrameworkCore;

namespace ac_web_test_api.Services
{
    public class InvoiceService : IInvoice
    {
        private readonly ApiDbContext _context;
        public InvoiceService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> AddInvoice(Invoice invoice)
        {
            // we run this query in pgadmin CREATE SEQUENCE invNumber INCREMENT 1 START 1;
            using var con = _context.Database.GetDbConnection();
            con.Open();
            var query = con.CreateCommand();
            query.CommandText = "SELECT NEXTVAL('invNumber')";
            var result = query.ExecuteScalar();
            var _id = int.TryParse(result.ToString(), out var r) ? r : throw new ArgumentNullException();
            var getDate = DateTime.Now;
            string year = getDate.Year.ToString();
            var newInvNumber = $"INV{year}{result.ToString().PadLeft(3, '0')}";
            var newInvoice = new Invoice()
            {
                invNumber = newInvNumber,
                invSum = invoice.invSum,
                currency = invoice.currency,
                corpName = invoice.corpName,
                companyId = invoice.companyId
            };
            await _context.invoice.AddAsync(newInvoice);
            await _context.SaveChangesAsync();
            return newInvoice;
        }

        public async Task<InvoiceResponse<IEnumerable<Invoice>>> GetAllInvoices()
        {
            InvoiceResponse<IEnumerable<Invoice>> InvoiceResponse = new InvoiceResponse<IEnumerable<Invoice>>();
            var allInvoices = await _context.invoice.AsTracking().ToListAsync();
            InvoiceResponse.invoices = allInvoices;
            return InvoiceResponse;
        }


    }
}