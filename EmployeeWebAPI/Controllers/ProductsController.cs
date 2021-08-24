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

            // image URL-https://localhost:44389//261ed257-01e6-4864-87c4-cc77fd7395d0.jpg
            
            if (product.Image!=null)
            {
                var fileStream = new FileStream(filePath, FileMode.Create);
                product.Image.CopyTo(fileStream);
            }
            product.ImageUrl = filePath.Remove(0, 7);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut({"id"})]

        public IActionResult Put(int id, [FromForm] Product product)
        {
        var p = _dbContext.Products.Find(id);
        if(p==null)
        {
            return NotFound("not found");
        }

        else
        {
            var guid = Guid.NewGuid();
            var filePath=Path.Combine("wwwroot",guid+".jpg");
            if(product.Image!=null)
            {
                var fileStream = new FileStream(filePath, FileMode.Create);
                product.Image.CopyTo(fileStream);
                product.ImageUrl = filePath.Remove(0, 7);

            }

            p.ProductName = product.ProductName;
            p.Rating = product.Rating;
            p.Categories = product.Categories;
            p.SKU = product.SKU;
            p.Discount = product.Discount;
            p.Percentage = product.Percentage;
            p.Details = product.Details;
            p.Tag = product.Tag;
            p.Price = product.Price;
            p.Stock = product.Stock;

            _dbContext.SaveChanges();
            return OK("Updated Succeessfully");
        }

        }






    }
}
