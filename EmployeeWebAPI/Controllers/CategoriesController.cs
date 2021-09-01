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
    public class CategoriesController : ControllerBase
    {
        private EmployeeContext _dbContext;

        public CategoriesController(EmployeeContext context)
        {
            _dbContext = context;
        }


        [HttpGet("[action]")]
        public IActionResult FindEmployee(string category)
        {
            var products = from product in _dbContext.Products
                            where product.Categories.Contains(category) //Searching Concept
                            select new
                            {
                                Id = product.Id,
                                ProductName = product.ProductName,
                                Rating = product.Rating,
                                Price = product.Price,
                                Discount = product.Discount,
                                Percentage = product.Percentage,
                                Details = product.Details,
                                Stock = product.Stock,
                                SKU = product.SKU,
                                Categories = product.Categories,
                                Tag = product.Tag,
                                ImageUrl = product.ImageUrl
                            };

            return Ok(products);
        }
    }
}
