using Microsoft.EntityFrameworkCore;
using PizzaArena_API.Data;
using PizzaArena_API.Models;
using PizzaArena_API.Services.GlobalSettingsFolder.Dtos;
using PizzaArena_API.Services.GlobalSettingsFolder.IGlobalService;

namespace PizzaArena_API.Services.GlobalSettingsFolder
{
    public class GlobalSettingsService : IGlobalSettings
    {
        private readonly PizzArenaDbContext _context;

        public GlobalSettingsService(PizzArenaDbContext context)
        {
            _context = context;
        }

        public async Task<GlobalSettings?> GetSettings()
        {
            return await _context.globalSettings.FirstOrDefaultAsync();
        }

        public async Task<GlobalSettings?> UpdateSettings(GlobalSettingsDto.GlobalDto settingsDto)
        {
            var settings = await _context.globalSettings.FirstOrDefaultAsync();

            if (settings == null)
            {
                return null;
            }


            settings.FacebookUrl = settingsDto.FacebookUrl;
            settings.InstagramUrl = settingsDto.InstagramUrl;
            settings.ContactEmail = settingsDto.ContactEmail;
            settings.DeliveryTime = settingsDto.DeliveryTime;

            await _context.SaveChangesAsync();
            return settings;
        }
    }
}
