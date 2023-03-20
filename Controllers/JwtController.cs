using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mobile.Domain1.Data;
using Mobile.Domain1.jwt;
using Mobile.Domain1.Model;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace MobileDemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
     
        private readonly MobileDbContext _ctx;
        private readonly CustomerJwt _customerJwt;

        public JwtController(MobileDbContext customerctx, IOptions<CustomerJwt> options)
        {
            _ctx = customerctx;
            _customerJwt = options.Value;
        }

        [AllowAnonymous]
        [HttpPost("Authentication")]

        public IActionResult Authentication([FromBody] JwtLogin customer)
        {
            var _customer = _ctx.customers.FirstOrDefault(l => l.Email == customer.Email && l.Password == customer.Password);
            if (_customer == null)
                return Unauthorized();

            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(_customerJwt.Secretkey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
            new Claim[]
            {
           new Claim(ClaimTypes.Name,_customer.CustomerName.ToString()),
            }
            ),
                Expires = DateTime.Now.AddSeconds(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenhandler.WriteToken(token);
            return Ok(finaltoken);
        }
    }


}

