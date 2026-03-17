using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PizzaArena_API.Data;
using PizzaArena_API.Models;

namespace PizzaArena_API.Services.SettingFolder
{
    public class SettingSetService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AdminSet _adminsettings;
        private readonly GlobalSettings _globalSettings;
        private readonly PizzArenaDbContext _context;

        public SettingSetService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<AdminSet> adminsettings, IOptions<GlobalSettings> globalSettings, PizzArenaDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _adminsettings = adminsettings.Value;
            _globalSettings = globalSettings.Value;
            _context = context;
        }


        //public SettingSetService(
        //    UserManager<User> userManager,
        //    RoleManager<IdentityRole> roleManager,
        //    IOptions<AdminSet> settings)
        //{
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //    _settings = settings.Value;
        //}



        public async Task SetAdmin()
        {
            var admin = await _userManager.FindByNameAsync(_adminsettings.UserName);

            if (admin == null)
            {
                admin = new User
                {
                    UserName = _adminsettings.UserName,
                    Email = _adminsettings.Email
                };

                await _userManager.CreateAsync(admin, _adminsettings.Password);



                if (!await _roleManager.RoleExistsAsync("Admin"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }


        public async Task SetGlobalSettings()
        {
            var globalb = await _context.globalSettings.FirstOrDefaultAsync();

            if (globalb == null)
            {
                var global = new GlobalSettings
                {
                    ContactEmail = _globalSettings.ContactEmail,
                    DeliveryTime = _globalSettings.DeliveryTime,
                    FacebookUrl = _globalSettings.FacebookUrl,
                    InstagramUrl = _globalSettings.InstagramUrl
                };

                await _context.globalSettings.AddAsync(global);

                await _context.SaveChangesAsync();
            }

        }



    }
}
