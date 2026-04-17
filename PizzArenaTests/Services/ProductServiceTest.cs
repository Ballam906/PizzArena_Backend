using Microsoft.EntityFrameworkCore;
using PizzaArena_API.Data;
using PizzaArena_API.Models;
using PizzaArena_API.Services.ProductFolder;
using PizzaArena_API.Services.ProductFolder.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace PizzArenaTests.Services
{
    public class ProductServiceTest
    {
        private PizzArenaDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<PizzArenaDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new PizzArenaDbContext(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }

        [Fact]
        public async Task AddProduct_SavesNewProductToDatabase()
        {
            var context = GetDbContext();
            var service = new ProductService(context);
            var dto = new ProductDto.ProductAddDto("Pizza", "Egesz jo", 1222, true, "", 1);

            var result = await service.AddProduct(dto);

            result.Id.Should().NotBe(0);
            context.products.Count().Should().Be(1);
            context.products.First().Name.Should().Be("Pizza");
        }

        [Fact]
        public async Task GetProductById_ReturnsCorrectProduct_WhenIdExists()
        {
            var context = GetDbContext();
            var testProduct = new Product { CategoryId = 2, Description = "", Name = "Teszt Pizza", Id = 2, IsAvailable = true, Image_Url = "", Price = 2200 };
            context.products.Add(testProduct);
            await context.SaveChangesAsync();

            var service = new ProductService(context);

            var result = await service.GetProductById(2);

            result.Should().NotBeNull();
            result.Name.Should().Be("Teszt Pizza");
        }

        [Fact]
        public async Task DeleteProduct_ReturnsFalse_IfProductNotFound()
        {
            var context = GetDbContext();
            var service = new ProductService(context);

            var result = await service.DeleteProduct(999);

            result.Should().BeFalse();
        }

        [Fact]
        public async Task UpdateProduct_UpdatesFieldsAndModTime()
        {
            var context = GetDbContext();
            var originalProduct = new Product { CategoryId = 2, 
                Description = "", Name = "Teszt Pizza", Id = 2,
                IsAvailable = true, Image_Url = "", Price = 2200 };
            context.products.Add(originalProduct);
            await context.SaveChangesAsync();

            var service = new ProductService(context);
            var updateDto = new ProductDto.ProductUpdateDto("Új Név", "Oke", 1500, true, "", 1);

            var result = await service.UpdateProduct(2, updateDto);

            result.Should().NotBeNull();
            result.Name.Should().Be("Új Név");
            result.Price.Should().Be(1500);

            var dbProduct = await context.products.FindAsync(2);
            dbProduct.ModTime.Should().NotBe(default(DateTime));
        }
    }
}
