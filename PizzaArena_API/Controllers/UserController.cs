using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaArena_API.Migrations;
using PizzaArena_API.Services.UserFolder.IUserService;
using static PizzaArena_API.Services.UserFolder.Dtos.UserDto;

namespace PizzaArena_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpPost("register")]
        public async Task<ActionResult> AddNewUser(RegisterRequestDto registerRequestDto)
        {
            var user = await _user.Register(registerRequestDto);

            if (user != null)
            {
                return StatusCode(201, user);
            }

            return BadRequest(new { result = "", message = "Sikertelen regisztráció" });
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginUser(LoginRequestDto loginRequestDto)
        {
            var res = await _user.Login(loginRequestDto);

            if (res != null)
            {
                return StatusCode(200, res);
            }

            return NotFound(res);
        }

        [HttpDelete("deleteuser")]
        public async Task<ActionResult> DeleteUser(string userid)
        {
            /*foreach (var c in User.Claims)
                Console.WriteLine($"{c.Type} = {c.Value}");*/

            var currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)
                     ?? User.FindFirst("sub");

            if (currentUserId == null)
            {
                return Unauthorized("Nincs bejelentkezve");
            }

            var current = currentUserId.Value;

            try
            {
                var res = await _user.DeleteUser(current, userid);
                return Ok(res); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }

        }

        [HttpPost("loginadmin")]
        public async Task<ActionResult> LoginUserAdmin(LoginRequestDto loginRequestDto)
        {
            var res = await _user.Login(loginRequestDto);

            if (res != null)
            {
                dynamic r = res;
                string userid = r.result.Id;
                var isAdmin = await _user.IsInRoleAsync(userid, "Admin");
                if (!isAdmin)
                {
                    return Unauthorized("Nincs jogosultság");
                }
                return StatusCode(200, res);
            }

            return NotFound(res);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("assignrole")]
        public async Task<ActionResult> AddRole(string UserName, string RoleName)
        {
            var res = await _user.AssignRole(UserName, RoleName);

            if (res != null)
            {
                return StatusCode(200, res);
            }

            return BadRequest(res);
        }
    }
}
