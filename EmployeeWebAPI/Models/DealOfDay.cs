using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models
{
    public class DealOfDay
    {
        [Key]
        public int DealId { get; set; }
        public int ProductId { get; set; }
    }
}
