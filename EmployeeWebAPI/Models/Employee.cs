using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DateOfJoining { get; set; }
        public double Salary { get; set;}

        
        // Foreign key   
        [Display(Name = "Department")]
        public virtual int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        /*
        public int DepartmentID
        {
            get;
            set;
        } //Foreign Key    
        public virtual Department Department
        {
            get;
            set;
        } //Navigation Property

        */

    }
}
