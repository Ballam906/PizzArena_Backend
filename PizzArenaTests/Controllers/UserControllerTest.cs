using Microsoft.AspNetCore.Mvc;
using Moq;
using PizzaArena_API.Controllers;
using PizzaArena_API.Services.UserFolder.IUserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PizzaArena_API.Services.UserFolder.Dtos.UserDto;
using FluentAssertions;
using System.Dynamic; 

namespace PizzArenaTests.Controllers
{
    public class UserControllerTest
    {
        private readonly Mock<IUser> _userMock;
        private readonly UserController _controller;

        public UserControllerTest()
        {
            _userMock = new Mock<IUser>();

            _controller = new UserController(_userMock.Object);
        }

        [Fact]
        public async Task Register_ReturnsCreated_OnSuccessfulRegistration()
        {
            var request = new RegisterRequestDto("teszt", "teszt@gmail.com", "Jelszo123");

            dynamic mockResponse = new ExpandoObject();
            mockResponse.message = "Sikeres regisztráció.";

            _userMock.Setup(s => s.Register(It.IsAny<RegisterRequestDto>()))
                     .ReturnsAsync((object)mockResponse);

            var result = await _controller.AddNewUser(request);

            var objectResult = result.Should().BeOfType<ObjectResult>().Subject;
            objectResult.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task Login_ReturnsNotFound_WhenUserDoesNotExist()
        {
            var request = new LoginRequestDto("nemletezik", "123");
            _userMock.Setup(s => s.Login(request)).ReturnsAsync((object)null);

            var result = await _controller.LoginUser(request);

            result.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}
