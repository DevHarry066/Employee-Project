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

     
        [HttpPost]
        public IActionResult Post(CartItem cartItem)
        {
            cartItem.CartId = "FDC123";
            _dbContext.ShoppingCartItems.Add(cartItem);
            _dbContext.SaveChanges();
            return Ok("Added Successfully into cart");

        }


        [HttpGet]
        public IActionResult GetCartDetails()
        {
            var carts = from cart in _dbContext.ShoppingCartItems
                        join product in _dbContext.Products
                        on cart.ProductId equals product.Id
                        select new
                        {
                            Id = cart.ItemId,
                            imageUrl = product.ImageUrl,
                            productName=product.ProductName,
                            price = product.Price,
                            quantity = cart.Quantity
                        };

            return Ok(carts);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cart=_dbContext.ShoppingCartItems.Find(id);
            if (cart == null) return Ok("Not Found");
            _dbContext.ShoppingCartItems.Remove(cart);
            _dbContext.SaveChanges();
            return Ok("Removed item from cart");

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

    }
}
