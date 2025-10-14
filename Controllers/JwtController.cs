using ClinicAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {

        [HttpPost]
        public ActionResult Login(UserDataDTO user)
        {


            // validate user
            if (user.username.ToLower() =="hassan" && user.password=="123")
            {

                //claims
                List<Claim> userdata = new List<Claim>();
                userdata.Add(new Claim("name", user.username));
                userdata.Add(new Claim(ClaimTypes.MobilePhone,"01002143030"));



                // preparing key
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("JwtSettings:SecretKey"));
                var signCr =new SigningCredentials(key,SecurityAlgorithms.HmacSha256);


                 // generate token
                var token = new JwtSecurityToken(

                    claims: userdata,
                    expires:DateTime.Now.AddDays(1),
                    signingCredentials:signCr
                    
                    );
                
                string stringToken = new JwtSecurityTokenHandler().WriteToken(token);


                return Ok(stringToken);

                

            }

            else return Unauthorized();





        }
    }
}

