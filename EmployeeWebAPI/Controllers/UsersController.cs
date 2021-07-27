using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using AuthenticationPlugin;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EmployeeWebAPI.Controllers
{
    public class UsersController : Controller
    {
        private EmployeeContext _dbContext;
        private IConfiguration _configuration;
        private readonly AuthService _auth;
        public UsersController(EmployeeContext context, IConfiguration configuration)
        {
            _dbContext = context;
            _configuration = configuration;
            _auth = new AuthService(_configuration);
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromBody] User user)
        {
            var e = _dbContext.Users.Where(u => u.Email == user.Email).SingleOrDefault();
            if (e != null) return BadRequest("Email already Registred");

            var user1 = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = SecurePasswordHasherHelper.Hash(user.Password), //Change stored procedure of password from string to Hashing
                Role = user.Role
            };

            _dbContext.Users.Add(user1);
            _dbContext.SaveChanges();
            return new JsonResult("Added Successfully");

        }


        [HttpGet("[action]")]
        public IActionResult LogIn(string email,string password)
        {
            //password = SecurePasswordHasherHelper.Hash(password);

            var e = _dbContext.Users.Where(u => u.Email == email).SingleOrDefault(); //Check Email
            if (e == null) return new JsonResult("Email not Registred");
            //return new JsonResult(email + "  " + password);

            if (!SecurePasswordHasherHelper.Verify(password, e.Password)) return new JsonResult("Wrong Password"); //Check Password

            var claims = new[]
            {
              new Claim(JwtRegisteredClaimNames.Email, e.Email),
              new Claim(ClaimTypes.Email, e.Email),
              new Claim(ClaimTypes.Role,e.Role)
             };

            var token = _auth.GenerateAccessToken(claims);

            //return Token
            return new JsonResult(token.AccessToken);
            return new JsonResult(new
            {
                access_token = token.AccessToken
                /*,
                expires_in = token.ExpiresIn,
                token_type = token.TokenType,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
                */
            });
        }
    }
}
