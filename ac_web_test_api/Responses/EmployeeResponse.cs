using System;
namespace ac_web_test_api.Responses
{
    public class EmployeeResponse<T>
    {
        public T employees { get; set; }
    }
}
