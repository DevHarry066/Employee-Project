using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models
{
    public class CartItem
    {
        [Key]
        public int ItemId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
