using my_another_mvc_web_app.Entities;
using my_another_mvc_web_app.Models;

namespace my_another_mvc_web_app.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto userDto);
        Task<string?> LoginAsync(UserDto userDto);
    }
}
