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
    public class DepartmentsController : ControllerBase
    {
        private EmployeeContext _dbContext;

        public DepartmentsController(EmployeeContext context)
        {
            _dbContext = context;
        }

            [HttpPost]
        public async Task<ActionResult<Department>> Post(Department department)
        {
            _dbContext.Departments.Add(department); //Add new Employee details
            await _dbContext.SaveChangesAsync();
            return new JsonResult("Added Successfully");
            //return StatusCode(StatusCodes.Status201Created);
        }

    }
}
