namespace PizzaArena_API.Services.UserFolder.Dtos
{
    public class UserDto
    {
        public record RegisterRequestDto(string UserName, string Email, string Password);

        public record LoginRequestDto(string UserName, string Password);

        public record PasswordChangeDto(string UserName, string Password, string NewPassword);
    }
}
