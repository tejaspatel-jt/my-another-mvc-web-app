namespace my_another_mvc_web_app.Models
{
    public class RefreshTokenRequestDto
    {
        public Guid UserId { get; set; }

        public required string RefreshToken { get; set; }
    }
}
