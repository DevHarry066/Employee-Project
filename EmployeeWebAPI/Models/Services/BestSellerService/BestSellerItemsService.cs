using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models.Services.BestSellerService
{
    public class BestSellerItemsService:IBestSellerItemsService
    {
        private readonly EmployeeContext _dbContext;

        public BestSellerItemsService(EmployeeContext context)
        {
            _dbContext = context;
        }

        public IQueryable GetBestSellerProducts()
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
            return bestSellers;
        }

        public string AddSellerProductIntoDatabase(int productId)
        {
            var bestSeller = new BestSellerItem();
            bestSeller.ProductId = productId;
            _dbContext.BestSellerItems.Add(bestSeller);
            _dbContext.SaveChanges();
            return "Best Seller Item Added Successfully";

        }

        public string RemoveBestSellerItemFromDatabase(int id)
        {
            var d = _dbContext.BestSellerItems.Find(id);
            if (d == null) return "Not available";

            _dbContext.BestSellerItems.Remove(d);
            _dbContext.SaveChanges();
            return "Removed from Database";

        }
    }
}
