using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private EmployeeContext _dbContext;

        public EmployeeController(EmployeeContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await _dbContext.Employees.ToListAsync();
            //return StatusCode(StatusCodes.Status200OK);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public IActionResult GetWithId(int id)
        {
            var c = _dbContext.Employees.Find(id);  //Get Employee with Id
            if (c == null) return NotFound("Employee Not Found");
            return Ok(c);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            _dbContext.Employees.Add(employee); //Add new Employee details
            await _dbContext.SaveChangesAsync();
            return new JsonResult("Added Successfully");
            //return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut]
        public async Task<IActionResult> Put(Employee employee)
        {
            
            var c = _dbContext.Employees.Find(employee.EmployeeId);
            if (c == null) return NotFound("Id not found"+ employee.EmployeeId);

            c.EmployeeName = employee.EmployeeName;
            c.Department = employee.Department;
            c.DateOfJoining = employee.DateOfJoining;
            await _dbContext.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
            
            //return Ok("Employee Details updated successfully"+employee.EmployeeId);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var c = _dbContext.Employees.Find(id);
            if (c == null) return NotFound("Id not found in database");
            _dbContext.Employees.Remove(c); //Delete Employee
            _dbContext.SaveChanges();
            return new JsonResult("Deleted Successfully");
        }

        //Find api/<EmployeesController>/5
        [HttpGet("[action]")]
        public IActionResult FindEmployee(string employeeName)
        {
            var employees = from employee in _dbContext.Employees
                            where employee.EmployeeName.StartsWith(employeeName) //Searching Concept
                            select new
                            {
                                EmployeeId = employee.EmployeeId,
                                EmployeeName = employee.EmployeeName,
                                Department = employee.Department,
                                DateOfJoining = employee.DateOfJoining,
                                
                            };

            return Ok(employees);
        }
    }
}
