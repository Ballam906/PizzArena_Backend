using PizzaArena_API.Models;

namespace PizzaArena_API.Services.UserFolder.IUserService
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user, IEnumerable<string> role);
    }
}
