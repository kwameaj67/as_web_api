using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ac_web_test_api.Models
{
    public class Invoice
    {
        [Key]
        public string invNumber { get; set; }
        public int invSum { get; set; }
        public string currency { get; set; }
        public string corpName { get; set; }
        public int companyId { get; set; }
        [JsonIgnore]
        public Company company { get; set; }
    }
}
