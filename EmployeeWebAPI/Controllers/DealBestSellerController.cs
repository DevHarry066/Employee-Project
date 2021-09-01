﻿using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

/*
        [HttpGet]
        public IEnumerable<Product> GetDealProducts()
        {
            return _dbContext.Products.Take(4);
        }
  */      

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

        [HttpPost]
        public IActionResult Post(int productId)
        {
            var product = _dbContext.Products.Find(productId);

            var deal = new DealOfDay();
            deal.ProductId = productId;
            deal.Product = product;
            _dbContext.DealOfDays.Add(deal);
            _dbContext.SaveChanges();
            return Ok("Deal Product Added");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

           var d= _dbContext.DealOfDays.Find(id);
            if (d == null) return Ok("Not available");

            _dbContext.DealOfDays.Remove(d);
            _dbContext.SaveChanges();
            return Ok("Deleted");


        }

        [HttpGet("[action]")]
        public IEnumerable<Product> GetBestSeller()
        {
            return _dbContext.Products.Skip(2).Take(6);
        }
    }
}
