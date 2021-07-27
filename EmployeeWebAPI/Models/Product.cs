using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }
        public int Stock { get; set; }
        public string SKU { get; set; }
        
        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }

    }
}
