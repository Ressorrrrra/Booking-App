using Booking_App.Server.Controllers;
using Booking_App.Server.DTO;
using Booking_App.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.AspNetCore.Identity;


namespace booking_app.Tests
{
    public class AuthTests
    {
        private Mock<IUserService> userServiceMock;
        private AccountsController controller;
        public AuthTests()
        {
            userServiceMock = new Mock<IUserService>();
            controller = new AccountsController(userServiceMock.Object);
        }

        //[Fact]
        //public async Task Register_WithValidData_ReturnsOk()
        //{
        //    // Arrange
        //    var registrationRequest = new RegistrationRequest() { Email = "test_user", Password = "password123" };
        //    IdentityResult identityResult = new IdentityResult();
        //    identityResult.Succeeded = true;
        //    userServiceMock.Setup(service => service.Register(registrationRequest)).ReturnsAsync(new IdentityResult { Succeeded = true }); ;

        //    // Act
        //    var result = await controller.Register(registrationRequest);

        //    // Assert
        //    var okObjectResult = Assert.IsType<OkObjectResult>(result);
        //}

        //[Fact]
        //public async Task Register_WithInvalidData_ReturnsBadRequest()
        //{
        //    // Arrange
        //    var registrationRequest = new RegistrationRequest() { Email = "", Password = "" }; // Ошибочные данные
        //    controller.ModelState.AddModelError("Email", "Имя пользователя должно быть заполнено.");
        //    controller.ModelState.AddModelError("Password", "Пароль должен быть заполнен.");

        //    // Act
        //    var result = await controller.Register(registrationRequest);

        //    // Assert
        //    var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
        //    var responseValue = Assert.IsAssignableFrom<object>(badRequestObjectResult.Value);
        //    //Assert.Equal("Неверные входные данные", ((dynamic)responseValue).message);
        //    Assert.NotNull(((dynamic)responseValue).error);
        //}

        [Fact]
        public async Task Login_WithValidData_ReturnsOk()
        {
            // Arrange
            var loginRequest = new LogInRequest() { Email = "test_user", Password = "password123" };
            var expectedResponse = new UserDataDto() { Id = "string", UserName = "test_user", UserRole = "Admin" };

            userServiceMock.Setup(service => service.LogIn(loginRequest)).ReturnsAsync(expectedResponse);

            // Act
            var result = await controller.Login(loginRequest);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            UserDataDto responseValue = Assert.IsAssignableFrom<UserDataDto>(okObjectResult.Value);
            //Assert.Equal("Выполнен вход", ((dynamic)responseValue).message);

            Assert.Equal(expectedResponse.UserName, responseValue.UserName);
            Assert.Equal(expectedResponse.UserRole, responseValue.UserRole);
            Assert.Equal(expectedResponse.Id, responseValue.Id);
        }

        [Fact]
        public async Task Login_WithInvalidData_ReturnsUnauthorized()
        {
            // Arrange
            var loginRequest = new LogInRequest() { Email = "", Password = "" }; // Ошибочные данные
            controller.ModelState.AddModelError("Username", "Имя пользователя должно быть заполнено.");
            controller.ModelState.AddModelError("Password", "Пароль должен быть заполнен.");

            // Act
            var result = await controller.Login(loginRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Login_WithIncorrectCredentials_ReturnsUnauthorized()
        {
            // Arrange
            var loginRequest = new LogInRequest() { Email = "test_user", Password = "wrong_password" };

            userServiceMock.Setup(service => service.LogIn(loginRequest)).ReturnsAsync((UserDataDto?)null);

            // Act
            var result = await controller.Login(loginRequest);

            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result);

        }
    }
}