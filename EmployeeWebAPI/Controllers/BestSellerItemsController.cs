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
            var id1 = new List<int>();

            var productIds = from productId in _dbContext.BestSellerItems
                             select new
                             {
                                 Id = productId.ProductId
                             };


            var ids = productIds.ToList();

            foreach (var id in ids)
            {
                id1.Add(id.Id);
            }

            var rows = _dbContext.Products.Where(t => id1.Contains(t.Id));
            return Ok(rows);
        }

        [HttpPost]
        public IActionResult Post(int productId)
        {
            var product = _dbContext.Products.Find(productId);

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
