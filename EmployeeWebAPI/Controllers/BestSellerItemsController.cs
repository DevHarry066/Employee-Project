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
    public class BestSellerItemsController : ControllerBase
    {
        private EmployeeContext _dbContext;

        public BestSellerItemsController(EmployeeContext context)
        {
            _dbContext = context;
        }

        [HttpGet("[action]")]
        public IActionResult GetBestSellerDeal()
        {


            var bestSellers = from seller in _dbContext.BestSellerItems
                        join product in _dbContext.Products
                        on seller.ProductId equals product.Id
                        select new
                        {
                            Id = product.Id,
                            imageUrl = product.ImageUrl,
                            productName = product.ProductName,
                            price = product.Price,
                            discount = product.Discount,
                            percentage = product.Percentage
                        };

            return Ok(bestSellers);
        }

        [HttpPost]
        public IActionResult Post(int productId)
        {
            var bestSeller = new BestSellerItem();
            bestSeller.ProductId = productId;
            _dbContext.BestSellerItems.Add(bestSeller);
            _dbContext.SaveChanges();
            return Ok("Deal Product Added");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var d = _dbContext.BestSellerItems.Find(id);
            if (d == null) return Ok("Not available");

            _dbContext.BestSellerItems.Remove(d);
            _dbContext.SaveChanges();
            return Ok("Deleted");

        }
    }
}
