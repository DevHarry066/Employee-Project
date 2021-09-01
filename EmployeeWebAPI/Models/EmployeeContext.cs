using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }
        
       // public DbSet<Employee> Employees { get; set; }
        public DbSet<Employee> Employeess { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<DealOfDay> DealOfDays { get; set; }
        public DbSet<BestSellerItem> BestSellerItems { get; set; }

    }
}
