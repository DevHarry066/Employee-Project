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
    public class ContactFormController : ControllerBase
    {
        private EmployeeContext _dbContext;

        public ContactFormController(EmployeeContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        public async Task<ActionResult<Form>> Post(Form form)
        {
            _dbContext.Forms.Add(form); 
            await _dbContext.SaveChangesAsync();
            return new JsonResult("Your form is submtted, we will reach to you");
        }
    }
}
