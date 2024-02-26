using CAPIV3.DTO;
using CAPIV3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CAPIV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Capiv3dbContext _db;
        private IConfiguration _Configuration;

        public LoginController(Capiv3dbContext db, IConfiguration configuration)
        {
            _db = db;
            _Configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PostLoginDetails")]
        public async Task<IActionResult> PostLoginDetails([FromForm]UserModel userData)
        {
            if (userData != null)
            {
                var resultLoginCheck = _db.TblUsers.Where(x => x.FullName == userData.FullName && x.Password == userData.Password).FirstOrDefault();
                if (resultLoginCheck == null)
                {
                    return BadRequest(":Invalid Cre");
                }
                else
                {
                    userData.UserMessage = "Login Successful";
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,_Configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,EpochTime.GetIntDate(DateTime.Now).ToString(CultureInfo.InvariantCulture),ClaimValueTypes.Integer64),
                        new Claim("UserId",userData.Id.ToString()),
                        new Claim("DisplayName",userData.EmailId.ToString()),
                        new Claim("UserName",userData.FullName.ToString()),
                        new Claim("Email",userData.EmailId)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken
                        (
                        _Configuration["Jwt:Issuer"],
                        _Configuration["Jwt:Audiance"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(150),
                        signingCredentials: signIn

                        );
                    userData.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(userData);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
