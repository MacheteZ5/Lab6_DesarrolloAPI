using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
namespace LAB6_1251518_1229918_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetToken()
        {
            string key = "Esto_Se_Supone_Que_Es_Una_Llava_Secreta";
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                    issuer: "Emisor",
                    audience: "Receptor",
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: credentials
                );
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }


    }
}