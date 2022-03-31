using System;
namespace ac_web_test_api.Responses
{
    public class InvoiceResponse<T>
    {
        public T invoices { get; set; }
    }
}
