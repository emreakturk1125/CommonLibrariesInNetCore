using NetCoreLibraries.AutoMapper.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.AutoMapper.Web.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string FullName { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime CreditCardValidDate { get; set; }
        public DateTime CCValidDate { get; set; } 
    }
}
