using PizzaArena_API.Models;
using static PizzaArena_API.Services.ProductFolder.Dtos.ProductDto;

namespace PizzaArena_API.Services.ProductFolder.IProductService
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product?> GetProductById(int id);
        Task<Product> AddProduct(ProductAddDto newproduct);
        Task<bool> DeleteProduct(int id);
        Task<Product?> UpdateProduct(int id,ProductUpdateDto upproduct);
    }
}
