namespace PizzaArena_API.Services.ProductFolder.Dtos
{
    public class ProductDto
    {
        public record ProductAddDto(string name, string description, int price, bool IsAvailable,string Image_Url, int CategoryId);
        public record ProductUpdateDto(string name, string description, int price, bool IsAvailable, string Image_Url, int CategoryId);
    }
}
