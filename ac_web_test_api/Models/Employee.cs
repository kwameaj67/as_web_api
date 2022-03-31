using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ac_web_test_api.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public int companyId { get; set; }
        [JsonIgnore]
        public Company company { get; set; }
    }
}
