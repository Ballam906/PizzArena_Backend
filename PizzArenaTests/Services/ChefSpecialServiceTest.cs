using Microsoft.EntityFrameworkCore;
using PizzaArena_API.Data;
using PizzaArena_API.Models;
using PizzaArena_API.Services.ChefSpecialFolder;
using PizzaArena_API.Services.ChefSpecialFolder.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace PizzArenaTests.Services
{
    public class ChefSpecialServiceTest
    {
        private PizzArenaDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<PizzArenaDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new PizzArenaDbContext(options);
        }

        [Fact]
        public async Task ChefAdd()
        {
            var context = GetDbContext();
            var service = new ChefSpecialService(context);
            var dto = new ChefDto.ChefAddDto(1, "Extra csípős");

            var result = await service.ChefAdd(dto);

            result.Id.Should().NotBe(0);
            context.chefSpecials.Count().Should().Be(1);
            context.chefSpecials.First().CustomNote.Should().Be("Extra csípős");
        }

        [Fact]
        public async Task ChefGetAllWithProduct()
        {
            var context = GetDbContext();

            var product = new Product
            {
                Id = 1,
                Name = "Séf Kedvence",
                Price = 3000,
                Description = "Leírás",
                Image_Url = "url",
                CategoryId = 1
            };
            var special = new ChefSpecial { Id = 1, ProductId = 1, CustomNote = "Megjegyzés" };

            context.products.Add(product);
            context.chefSpecials.Add(special);
            await context.SaveChangesAsync();

            var service = new ChefSpecialService(context);

            var result = await service.ChefGetAll();

            result.Should().NotBeEmpty();
            var firstItem = result.First();
            firstItem.Product.Should().NotBeNull();
            firstItem.Product.Name.Should().Be("Séf Kedvence");
        }

        [Fact]
        public async Task ChefModify()
        {
            var context = GetDbContext();
            var existing = new ChefSpecial { Id = 5, ProductId = 1, CustomNote = "Régi" };
            context.chefSpecials.Add(existing);
            await context.SaveChangesAsync();
            context.ChangeTracker.Clear();

            var service = new ChefSpecialService(context);
            var modDto = new ChefDto.ChefModDto(5,2,"Új"); 

            var result = await service.ChefModify(modDto);

            result.Should().NotBeNull();
            result.CustomNote.Should().Be("Új");
            result.ProductId.Should().Be(2);
        }

        [Fact]
        public async Task ChefDelete()
        {
            var context = GetDbContext();
            var special = new ChefSpecial { Id = 1, ProductId = 1, CustomNote = "Törlendő" };
            context.chefSpecials.Add(special);
            await context.SaveChangesAsync();

            var service = new ChefSpecialService(context);

            var success = await service.ChefDelete(1);

            success.Should().BeTrue();
            context.chefSpecials.Should().BeEmpty();
        }
    }
}
