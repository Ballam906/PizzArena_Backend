namespace PizzaArena_API.Services.CategoryFolder.Dtos
{
    public class CategoryDto
    {
        public record CreateCategoryDto(string Name);
        public record UpdateCategoryDto(string Name);
    }
}
