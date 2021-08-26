using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealBestSellerController : ControllerBase
    {
        private EmployeeContext _dbContext;

        public DealBestSellerController(EmployeeContext context)
        {
            _dbContext = context;
        }

        
        [HttpGet]
        public IEnumerable<Product> GetDeal()
        {
            return _dbContext.Products.Take(4);
        }

        [HttpGet("[action]")]
        public IEnumerable<Product> GetBestSeller()
        {
            return _dbContext.Products.Skip(2).Take(6);
        }
    }
}
