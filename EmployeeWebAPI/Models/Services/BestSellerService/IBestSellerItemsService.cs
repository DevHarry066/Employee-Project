using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models.Services.BestSellerService
{
    public interface IBestSellerItemsService
    {
        public IQueryable GetBestSellerProducts();
        public string AddSellerProductIntoDatabase(int productId);

        public string RemoveBestSellerItemFromDatabase(int id);

    }
}
