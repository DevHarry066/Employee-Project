using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models
{
    public class ProductTest
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public int Percentage { get; set; }
        public string Details { get; set; }
        public int Stock { get; set; }
        public string SKU { get; set; }
        public string Categories { get; set; }
        public string Tag { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
