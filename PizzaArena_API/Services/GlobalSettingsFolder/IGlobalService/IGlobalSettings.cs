using PizzaArena_API.Models;
using static PizzaArena_API.Services.GlobalSettingsFolder.Dtos.GlobalSettingsDto;

namespace PizzaArena_API.Services.GlobalSettingsFolder.IGlobalService
{
    public interface IGlobalSettings
    {
        Task<GlobalSettings?> GetSettings();
        Task<GlobalSettings?> UpdateSettings(GlobalDto settingsDto);
    }
}
