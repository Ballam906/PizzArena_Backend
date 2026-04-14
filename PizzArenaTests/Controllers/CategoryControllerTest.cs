using Microsoft.AspNetCore.Mvc;
using Moq;
using PizzaArena_API.Controllers;
using PizzaArena_API.Models;
using PizzaArena_API.Services.CategoryFolder.Dtos;
using PizzaArena_API.Services.CategoryFolder.ICategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace PizzArenaTests.Controllers
{
    public class CategoryControllerTest
    {
        private readonly Mock<ICategory> _categoryMock;
        private readonly CategoryController _controller;

        public CategoryControllerTest()
        {
            _categoryMock = new Mock<ICategory>();
            _controller = new CategoryController(_categoryMock.Object);
        }

        [Fact]
        public async Task GetAllCategories()
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Pizza" },
                new Category { Id = 2, Name = "Üdítő" }
            };
            _categoryMock.Setup(s => s.GetAllCategory()).ReturnsAsync(categories);

            var result = await _controller.GetAll();

            var ok = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var resultsuccess = ok.Value.Should().BeAssignableTo<IEnumerable<Category>>().Subject;
            resultsuccess.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetByIdCategories()
        {
            _categoryMock.Setup(s => s.GetCategoryById(99)).ReturnsAsync((Category)null);

            var result = await _controller.GetById(99);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task CreateCategories()
        {
            var dto = new CategoryDto.CreateCategoryDto("Új Kategória");
            var createdCategory = new Category { Id = 5, Name = "Új Kategória" };

            _categoryMock.Setup(s => s.CategoryAdd(dto)).ReturnsAsync(createdCategory);

            var result = await _controller.Create(dto);

            var createdResult = result.Result.Should().BeOfType<CreatedAtActionResult>().Subject;
            createdResult.ActionName.Should().Be("GetById");
            createdResult.RouteValues["id"].Should().Be(5);
            createdResult.Value.Should().Be(createdCategory);
        }

        [Fact]
        public async Task DeleteCategories()
        {
            int targetId = 1;
            _categoryMock.Setup(s => s.CategoryDelete(targetId)).ReturnsAsync(true);

            var result = await _controller.Delete(targetId);

            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;

            okResult.Value.ToString().Should().Contain("Kategória törölve.");
        }
    }
}
