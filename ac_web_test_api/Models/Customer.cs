using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ac_web_test_api.Models
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        public string corpName { get; set; }
        public string address { get; set; }
        public int companyId { get; set; }
        [JsonIgnore]
        public Company company { get; set; }

    }
}
