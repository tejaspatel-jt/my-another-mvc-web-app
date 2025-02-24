using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using my_another_mvc_web_app.Entities;
using my_another_mvc_web_app.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace my_another_mvc_web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : ControllerBase
    {

        public static User user = new();

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto userDto)
        {
            var hashsedPassword = new PasswordHasher<User>()
                .HashPassword(user, userDto.Password);

            user.Username = userDto.Username;
            user.PasswordHash = hashsedPassword;

            //return user;

            //var user = new User
            //{
            //    Username = userDto.Username,
            //    PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password)
            //};
            //_context.Users.Add(user);
            //_context.SaveChanges();

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserDto userDto)
        {
            if(user.Username != userDto.Username)
            {
                return BadRequest("User Not Found");
            }

            var passwordVerificationResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, userDto.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return BadRequest("Invalid Password");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user) {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }
    }
}
