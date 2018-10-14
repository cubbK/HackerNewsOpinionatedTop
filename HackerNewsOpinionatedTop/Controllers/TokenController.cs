using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HackerNewsOpinionatedTopApi.Models;
using System.Linq;

namespace HackerNewsOpinionatedTopApi.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;
        private readonly HnContext _context;

        public TokenController(IConfiguration config, HnContext context, IConfiguration configuration)
        {
            _config = config;
            _context = context;

            int usersCount = context.Users.Count();
            if (usersCount == 0)
            {
                User admin = new User { Username = configuration["Admin:Username"], Password = configuration["Admin:Password"] };
                context.Users.Add(admin);
                context.SaveChanges();
            }

        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]Login login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string BuildToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddDays(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(Login login)
        {
            var userToCheck = _context.Users.FirstOrDefault(user => user.Username == login.Username);
            if (userToCheck == null) return null;

            if(userToCheck.Password == login.Password)
            {
              return userToCheck;
            } else
            {
            return null;
            }
        }
    }
}