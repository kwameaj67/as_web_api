using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ac_web_test_api.Models
{
    public class Company
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Employee> employees { get; set; }
        public ICollection<Customer> customers { get; set; }
        public ICollection<Invoice> invoices { get; set; }

    }
}
