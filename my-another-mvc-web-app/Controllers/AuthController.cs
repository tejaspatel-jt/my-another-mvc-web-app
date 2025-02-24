using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using my_another_mvc_web_app.Entities;
using my_another_mvc_web_app.Models;

namespace my_another_mvc_web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
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
        public ActionResult<User> Login(UserDto userDto)
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

            string token = "Success as a token";

            return Ok(token);
        }
    }
}
