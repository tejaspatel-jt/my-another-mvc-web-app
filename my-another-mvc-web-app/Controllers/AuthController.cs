using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using my_another_mvc_web_app.Entities;
using my_another_mvc_web_app.Models;
using my_another_mvc_web_app.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace my_another_mvc_web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto userDto)
        {
            var user = await authService.RegisterAsync(userDto);
            if(user is null)
                return BadRequest("Username Already Exists");

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto userDto)
        {
            var token = await authService.LoginAsync(userDto);
            if(token is null)
                return BadRequest("Invalid Username or Password");

            return Ok(token);
        }

    }
}
