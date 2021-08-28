using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private EmployeeContext _dbContext;

        public ShoppingCartController(EmployeeContext context)
        {
            _dbContext = context;
        }

       /* [HttpPost]
        public IActionResult Post(int productId)
        {
            var product = _dbContext.ShoppingCartItems.SingleOrDefault(c=>c.ProductId==productId);

            product = new CartItem
            {
                ProductId = productId,
                Product = _dbContext.Products.SingleOrDefault(p => p.Id == productId),
                Quantity = 1,
            };
            _dbContext.ShoppingCartItems.Add(product);
            _dbContext.SaveChanges();
            return Ok("Added Successfully");
        }
       */

        [HttpPost]
        public IActionResult Post(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            var cartItem = new CartItem
                           {
                               Product = product,
                               Quantity = 1,
                               ProductId=productId
                           };
            _dbContext.ShoppingCartItems.Add(cartItem);
            _dbContext.SaveChanges();
            return Ok("Added Successfully");

        }


        
      


    }
}
