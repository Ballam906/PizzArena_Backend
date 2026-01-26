using System.Reflection.Metadata;
using static PizzaArena_API.Services.UserFolder.Dtos.UserDto;

namespace PizzaArena_API.Services.UserFolder.IUserService
{
    public interface IUser
    {
        Task<object> Register(RegisterRequestDto registerRequestDto);
        Task<object> Login(LoginRequestDto loginRequestDto);
        Task<object> AssignRole(string UserName, string roleName);
        Task<bool> IsInRoleAsync(string userId, string roleName);
        Task<object> DeleteUser(string currentUserId, string targetUserId);
    }
}
