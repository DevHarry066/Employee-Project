using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private EmployeeContext _dbContext;

        public EmployeeController(EmployeeContext context)
        {
            _dbContext = context;
        }


        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
           // return await _dbContext.Employeess.ToListAsync();

            //var employees = _dbContext.Employeess.Include(e=>e.Department);
            //return employees.ToList();
            ////return StatusCode(StatusCodes.Status200OK);

            var emp = _dbContext.Employeess.ToList();
            var dep = _dbContext.Departments.ToList();

            var res = from e in emp
                      join d in dep on e.DepartmentId equals d.DepartmentId
                      select e;

            return res;



        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public IActionResult GetWithId(int id)
        {
            var c = _dbContext.Employeess.Find(id);  //Get Employee with Id
            if (c == null) return NotFound("Employee Not Found");
            return Ok(c);
        }

        

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
                _dbContext.Employeess.Add(employee); //Add new Employee details
                await _dbContext.SaveChangesAsync();
               return new JsonResult("Added Successfully");
                //return StatusCode(StatusCodes.Status201Created);
        }

        //[HttpPost]
        //public async Task<ActionResult<Employee>> PostEmployeeDepartment(Employee employee, Department department)
        //{

        //    _dbContext.Employeess.Add(employee); //Add new Employee details
        //    _dbContext.Departments.Add(department); //Add new Employee details

        //    await _dbContext.SaveChangesAsync();
        //    return new JsonResult("Added Successfully");

        //}


        // PUT api/<EmployeesController>/5
        [HttpPut]
        public async Task<IActionResult> Put(Employee employee)
        {
            
            var c = _dbContext.Employeess.Find(employee.EmployeeId);
            if (c == null) return NotFound("Id not found"+ employee.EmployeeId);

            c.EmployeeName = employee.EmployeeName;
            c.DateOfJoining = employee.DateOfJoining;
            await _dbContext.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
            
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var c = _dbContext.Employeess.Find(id);
            if (c == null) return NotFound("Id not found in database");
            _dbContext.Employeess.Remove(c); //Delete Employee
            _dbContext.SaveChanges();
            return new JsonResult("Deleted Successfully");
        }

        //Find api/<EmployeesController>/5
        [HttpGet("[action]")]
        public IActionResult FindEmployee(string employeeName)
        {
            var employees = from employee in _dbContext.Employeess
                            where employee.EmployeeName.StartsWith(employeeName) //Searching Concept
                            select new
                            {
                                EmployeeId = employee.EmployeeId,
                                EmployeeName = employee.EmployeeName,
                                DateOfJoining = employee.DateOfJoining,
                                
                            };

            return Ok(employees);
        }
    }
}
