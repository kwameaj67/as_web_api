using System;
namespace ac_web_test_api.Responses
{
    public class CustomerResponse<T>
    {
        public T Customers { get; set; }
    }
}
