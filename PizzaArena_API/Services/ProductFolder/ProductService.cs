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

        public async Task<object> AddProduct(ProductDto.ProductAddDto newproduct)
        {
            var newp = new Product
            {
                Price = newproduct.price,
                CategoryId = newproduct.CategoryId,
                Name = newproduct.name,
                Description = newproduct.description,
                IsAvailable = newproduct.IsAvailable,
                Image_Url = newproduct.Image_Url,

            };

            _context.products.Add(newp);
            await _context.SaveChangesAsync();
            return newproduct;
        }

        public async Task<object> DeleteProduct(int id)
        {
            var vane = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
            if (vane != null)
            {
                _context.products.Remove(vane);
                await _context.SaveChangesAsync();
                return new { message = "Sikeres törlés" };
            }

            return new { message = "Nincs ilyen produkt" };
        }

        public async Task<object> GetProductById(int id)
        {
            var vane = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
            if (vane != null)
            {
                return vane;
            }

            return new { message = "Nincs ilyen produkt" };
        }

        public async Task<object> GetProducts()
        {
            var products = await _context.products.ToListAsync();
            return products;
        }

        public async Task<object> UpdateProduct(int id, ProductDto.ProductUpdateDto upproduct)
        {
            var vane = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
            if (vane == null)
            {
                return new { message = "Nincs ilyen produkt!" };
            }
            vane.Price = upproduct.price;
            vane.ModTime = DateTime.Now;
            vane.CategoryId = upproduct.CategoryId;
            vane.Description = upproduct.description;
            vane.IsAvailable = upproduct.IsAvailable;
            vane.Image_Url = upproduct.Image_Url;
            vane.Name = upproduct.name;

            _context.products.Update(vane);
            await _context.SaveChangesAsync();

            return new { result = vane, message = "Sikeres frissítés" };
        }
    }
}
