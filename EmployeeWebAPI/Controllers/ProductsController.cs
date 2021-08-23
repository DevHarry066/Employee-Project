using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private EmployeeContext _dbContext;

        public ProductsController(EmployeeContext context)
        {
            _dbContext = context;
        }
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products;
        }

        [HttpPost]
        public IActionResult Post([FromForm] Product product)
        {
            var guid = Guid.NewGuid();

            var filePath = Path.Combine("wwwroot", guid + ".jpg");

            if(product.Image!=null)
            {
                var fileStream = new FileStream(filePath, FileMode.Create);
                product.Image.CopyTo(fileStream);
            }
            product.ImageUrl = filePath.Remove(0, 7);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
