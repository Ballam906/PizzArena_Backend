using Microsoft.EntityFrameworkCore;
using PizzaArena_API.Data;
using PizzaArena_API.Models;
using PizzaArena_API.Services.ProductFolder.Dtos;
using PizzaArena_API.Services.ProductFolder.IProductService;

namespace PizzaArena_API.Services.ProductFolder
{
    public class ProductService : IProduct
    {
        private readonly PizzArenaDbContext _context;

        public ProductService(PizzArenaDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(ProductDto.ProductAddDto newproduct)
        {
            var product = new Product
            {
                CategoryId = newproduct.CategoryId,
                Name = newproduct.name,
                Description = newproduct.description,
                Price = newproduct.price,
                IsAvailable = newproduct.IsAvailable,
                Image_Url = newproduct.Image_Url

            };

            _context.products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

             _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.products.ToListAsync();
        }

        public async Task<Product?> UpdateProduct(ProductDto.ProductUpdateDto upproduct)
        {
            var product = await _context.products.FindAsync(upproduct.Id);
            if (product == null) return null;

            product.Description = upproduct.description;
            product.Price = upproduct.price;
            product.IsAvailable = upproduct.IsAvailable;
            product.Name = upproduct.name;
            product.CategoryId = upproduct.CategoryId;
            product.Image_Url = upproduct.Image_Url;
            product.ModTime = DateTime.Now;

            
            //_context.products.Update(product);
            await _context.SaveChangesAsync();
            return product;

        }
    }
}
