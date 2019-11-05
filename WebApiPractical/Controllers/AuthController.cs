using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApiPractical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IActionResult GetToken(LoginModel request)
        {
            string value="test";
            if (value.Equals(request.username) && value.Equals(request.password))
            {
                //security key
                string securityKey = "493ab24b-0c99-3341-bf32-76037c2f36eb$localhost:52020";
                //symmetric security key
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

                //signing credentials
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

                //add claims
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
                claims.Add(new Claim(ClaimTypes.Role, "Reader"));
                //claims.Add(new Claim("Id", "110"));


                //create token
                var token = new JwtSecurityToken(
                    issuer: "localhost:52020",
                    audience: "readers",
                    expires: DateTime.Now.AddHours(1), // New token will change every 60 minutes.
                    signingCredentials: signingCredentials
                    , claims: claims
                );

                //return token
                return Ok(new {
                    id=0,
                    username=request.username,
                    firstName="test",
                    token= new JwtSecurityTokenHandler().WriteToken(token)
                });
              
            }

            return StatusCode(404);
        }
    }

    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}