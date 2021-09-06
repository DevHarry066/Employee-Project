using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models.Services
{
    public interface IDealOfDayService
    {
        public IQueryable GetDealProducts();
        public string AddDealIntoDatabase(int productId);
        public string DeleteDealProductFromDatabase(int productId);
    }
}
