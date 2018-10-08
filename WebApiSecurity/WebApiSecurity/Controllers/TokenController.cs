using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApiSecurity.Models;

namespace WebApiSecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("/api/token", Name ="Token")]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var usr = Authenticate(login);

            if (usr != null)
            {
                var token = BuildToken(usr);
                response = Ok(new { token = token });
            }
            return response;
        }
        private string BuildToken(UserModel user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name ),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Birthdate, user.BirthDate.ToString()), //"yyyy-mm-dd"
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], 
                _config["Jwt:Issuer"], 
                claims, 
                expires: DateTime.Now.AddMinutes(30), 
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(LoginModel login)
        {
            UserModel user = null;

            if (login.UserName == "rakesh" && login.Password == "thakur")
            {
                user = new UserModel
                {
                    Name = "Rakesh Thakur",
                    Email = "rakeshT2@hexaware.com",
                    BirthDate = "1979-05-01"
                };

            }
            return user;
        }
    }
}