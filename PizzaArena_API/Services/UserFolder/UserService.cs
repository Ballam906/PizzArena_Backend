using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzaArena_API.Data;
using PizzaArena_API.Models;
using PizzaArena_API.Services.UserFolder.Dtos;
using PizzaArena_API.Services.UserFolder.IUserService;

namespace PizzaArena_API.Services.UserFolder
{
    public class UserService : IUser
    {
        private readonly PizzArenaDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(PizzArenaDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ITokenGenerator tokenGenerator)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<object> AssignRole(string UserName, string roleName)
        {
            var user = await _context.users.FirstOrDefaultAsync(x => x.NormalizedUserName == UserName.ToUpper());

            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }

                await _userManager.AddToRoleAsync(user, roleName);

                return new { result = user, message = "Sikeres hozzárendelés." };
            }

            return new { result = "", message = "Sikertelen hozzárendelés." };
        }

        public async Task<object> DeleteUser(string currentUserId, string targetUserId)
        {
            var isAdmin = await IsInRoleAsync(currentUserId, "Admin");

            if (!isAdmin && currentUserId != targetUserId)
                return new {result = "", message = "Nincs jogosultság a felhasználó törlésére"};
            var user = await _userManager.FindByIdAsync(targetUserId);
            if (user == null)
                return new {result = "", message = "Felhasználó nem található"};
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return new {result = "", message = "Hiba a törlés során"};

            return new {result, message = "Felhasználó sikeresen törölve" };
        }

        public async Task<bool> IsInRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<object> Login(UserDto.LoginRequestDto loginRequestDto)
        {
            var user = await _context.users.FirstOrDefaultAsync(user => user.NormalizedUserName == loginRequestDto.UserName.ToUpper());

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (isValid)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var jwtToken = _tokenGenerator.GenerateToken(user, roles);
                Console.WriteLine($"Login user.Id: {user.Id}");
                return new { result = new { user.UserName, user.Email, user.Id }, message = "Sikeres belépés.", token = jwtToken };
            }

            return new { result = "", message = "Nem regisztrált", token = "" };
        }

        public async Task<object> Register(UserDto.RegisterRequestDto registerRequestDto)
        {
            var user = new User
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerRequestDto.Password);

            if (result.Succeeded)
            {
                var userReturn = await _context.users.FirstOrDefaultAsync(user => user.UserName == registerRequestDto.UserName);

                return new { result = userReturn, message = "Sikeres regisztráció." };
            }

            return new { result = "", message = result.Errors.FirstOrDefault().Description };
        }
    }
}
