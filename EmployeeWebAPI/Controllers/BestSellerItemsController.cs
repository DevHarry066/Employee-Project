using EmployeeWebAPI.Models;
using EmployeeWebAPI.Models.Services.BestSellerService;
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
        private IBestSellerItemsService bestSellerService;

        public BestSellerItemsController(IBestSellerItemsService bestSellerItemsService)
        {
            bestSellerService = bestSellerItemsService;
        }

        [HttpGet("[action]")]
        public IActionResult GetBestSellerDeal()
        {

            var bestSellers = bestSellerService.GetBestSellerProducts();
            return Ok(bestSellers);
        }

        [HttpPost]
        public IActionResult Post(int productId)
        {
            string message = bestSellerService.AddSellerProductIntoDatabase(productId);
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string message = bestSellerService.RemoveBestSellerItemFromDatabase(id);
            return Ok(message);
        }
    }
}
