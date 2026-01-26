namespace PizzaArena_API.Services.ChefSpecialFolder.Dtos
{
    public class ChefDto
    {
        public record ChefAddDto(int ProductId, string CustomNote);
        public record ChefModDto(int Id, int ProductId, string CustomNote);
    }
}
