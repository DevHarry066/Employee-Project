using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models.Services
{
    public class DealOfDayService:IDealOfDayService
    {
        private readonly EmployeeContext _dbContext;


        public DealOfDayService(EmployeeContext context)
        {
            _dbContext = context;
        }

        public IQueryable GetDealProducts()
        {
            var deals = from deal in _dbContext.DealOfDays
                        join product in _dbContext.Products
                        on deal.ProductId equals product.Id
                        select new
                        {
                            Id = product.Id,
                            imageUrl = product.ImageUrl,
                            productName = product.ProductName,
                            price = product.Price,
                            discount = product.Discount,
                            percentage = product.Percentage
                        };

            return deals;
        }

        public string AddDealIntoDatabase(int productId)
        {
            var deal = new DealOfDay();
            deal.ProductId = productId;
            _dbContext.DealOfDays.Add(deal);
            _dbContext.SaveChanges();
            return "Added Successfully";
        }

        public string DeleteDealProductFromDatabase(int productId)
        {
            var d = _dbContext.DealOfDays.Find(productId);
            if (d == null) return "Not available";

            _dbContext.DealOfDays.Remove(d);
            _dbContext.SaveChanges();
            return "Removed successfully";
        }
    }
}
