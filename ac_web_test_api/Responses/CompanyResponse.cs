using System;
namespace ac_web_test_api.Responses
{
    public class CompanyResponse<T>
    {
        public T employees { get; set; }
        public T customers { get; set; }
        public T invoices { get; set; }
    }
}
