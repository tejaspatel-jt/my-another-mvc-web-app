using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using my_another_mvc_web_app.Data;
using my_another_mvc_web_app.Entities;
using my_another_mvc_web_app.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace my_another_mvc_web_app.Services
{
    public class AuthService(UserDbContext context, IConfiguration configuration) : IAuthService
    {
        public async Task<string?> LoginAsync(UserDto userDto)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == userDto.Username);

            if (user is null)
            {
                return null;
            }

            var passwordVerificationResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, userDto.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return CreateToken(user);
        }

        public async Task<User?> RegisterAsync(UserDto userDto)
        {
            if(await context.Users.AnyAsync(u => u.Username == userDto.Username))
            {
                return null;
            }

            var user = new User();
            var hashsedPassword = new PasswordHasher<User>()
                .HashPassword(user, userDto.Password);

            user.Username = userDto.Username;
            user.PasswordHash = hashsedPassword;

            context.Users.Add(user);
            await context.SaveChangesAsync();
            
            return user;
        }


        private string CreateToken(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
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
