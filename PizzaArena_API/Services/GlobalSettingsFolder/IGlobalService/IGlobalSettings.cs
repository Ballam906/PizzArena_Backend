using static PizzaArena_API.Services.GlobalSettingsFolder.Dtos.GlobalSettingsDto;

namespace PizzaArena_API.Services.GlobalSettingsFolder.IGlobalService
{
    public interface IGlobalSettings
    {
        Task<object> GetSettings();
        Task<object> UpdateSettings(GlobalDto settingsDto);
    }
}
