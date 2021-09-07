using EmployeeWebAPI.Models;
using EmployeeWebAPI.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealBestSellerController : ControllerBase
    {
        private readonly IDealOfDayService dayService;

        public DealBestSellerController(IDealOfDayService service)
        {
            dayService = service;
        }


        [HttpGet]
        public IActionResult GetDealProducts()
        {

            var deals = dayService.GetDealProducts();
            return Ok(deals);         
        }
        
        [HttpPost]
        public IActionResult Post(int productId)
        {

            string message = dayService.AddDealIntoDatabase(productId);
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string message = dayService.DeleteDealProductFromDatabase(id);
            return Ok(message);
        }

        /*[HttpGet("[action]")]
        public IEnumerable<Product> GetBestSeller()
        {
            return _dbContext.Products.Skip(2).Take(6);
        }
        */
        /*
        [HttpGet("[action]")]
        public IActionResult GetDeal()
        {
            var id1 = new List<int>();
            
            var productIds = from productId in _dbContext.DealOfDays
                             select new
                             {
                                 Id = productId.ProductId
                             };

            
           var ids = productIds.ToList();
            
            foreach(var id in ids)
            {
                id1.Add(id.Id);
            }

            var rows = _dbContext.Products.Where(t => id1.Contains(t.Id));
            return Ok(rows);
        }
        */

    }
}
