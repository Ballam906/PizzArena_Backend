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

        public async Task<object> GetSettings()
        {
            var settings = await _context.globalSettings.FirstOrDefaultAsync();

            if (settings == null)
            {
                settings = new GlobalSettings
                {
                    ContactEmail = "ContactEmail",
                    DeliveryTime = "1",
                    FacebookUrl = "facebookurl",
                    InstagramUrl = "instagramurl"
                };

                _context.globalSettings.Add(settings);
                await _context.SaveChangesAsync();

                return new { result = settings, message = "Beállítások létrehozva." };
            }

            return new { result = settings, message = "Beállítások betöltve" };
        }

        public async Task<object> UpdateSettings(int id,GlobalSettingsDto.GlobalDto settingsDto)
        {
            var settings = await _context.globalSettings.FirstOrDefaultAsync(x => x.Id == id);
            if(settings == null)
            {
                return new { message = "Nincs ilyen beállítás!" };
            }

            settings.ContactEmail = settingsDto.ContactEmail;
            settings.DeliveryTime = settingsDto.DeliveryTime;
            settings.FacebookUrl = settingsDto.FacebookUrl;
            settings.InstagramUrl = settingsDto.InstagramUrl;

            _context.globalSettings.Update(settings);
            await _context.SaveChangesAsync();

            return new { result = settings, message = "Beállítások sikeresen frissítve." };
        }
    }
}
