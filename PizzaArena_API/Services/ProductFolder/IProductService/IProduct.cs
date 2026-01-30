using static PizzaArena_API.Services.ProductFolder.Dtos.ProductDto;

namespace PizzaArena_API.Services.ProductFolder.IProductService
{
    public interface IProduct
    {
        Task<object> GetProducts();
        Task<object> GetProductById(int id);
        Task<object> AddProduct(ProductAddDto newproduct);
        Task<object> DeleteProduct(int id);
        Task<object> UpdateProduct(int id,ProductUpdateDto upproduct);
    }
}
