namespace my_another_mvc_web_app.Models
{
    public class TokenResponseDto
    {
        public required string AccessToken { get; set; }

        public required string RefreshToken { get; set; }
    }
}
