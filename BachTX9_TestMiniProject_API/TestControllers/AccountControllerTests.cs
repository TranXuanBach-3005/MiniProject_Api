using AutoMapper;
using BachTX9_MiniProject_API.Controllers;
using BachTX9_MiniProject_API.DTOs.UserDtos;
using BachTX9_MiniProject_API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;
namespace BachTX9_TestMiniProject_API
{
    public class AccountControllerTests
    {
        private readonly AccountController _accountController;
        private readonly Mock<IAccountService> _mockAccountService;
        private readonly Mock<IMapper> _mockMapper;
        public AccountControllerTests()
        {
            _mockAccountService = new Mock<IAccountService>();
            _accountController = new AccountController(_mockAccountService.Object);
            _mockMapper = new Mock<IMapper>();
        }
        [Fact]
        public async Task Resgiter_Test()
        {
            var register = new UserRegisterDto { Email = "test", Password = "test", UserName = "test", }; _mockAccountService.Setup(x => x.Register(register)).ReturnsAsync("hello");
            var result = await _accountController.Register(register);
            Assert.Equal("hello", ((ObjectResult)result).Value);
        }
        [Fact]
        public async Task ResgiterTeacher_Test()
        {
            var register = new UserRegisterDto { Email = "test", Password = "test", UserName = "test" };
            _mockAccountService.Setup(x => x.RegisterTeacher(register)).ReturnsAsync("helloTeacher");
            var result = await _accountController.RegisterTeacher(register);
            Assert.Equal("helloTeacher", ((ObjectResult)result).Value);
        }
        [Fact]
        public async Task Login_Test()
        {
            var testLogin = new UserLoginDto
            {
                UserName = "admin",
                Password = "123456"
            };
            var result = await _accountController.Login(testLogin);
            Assert.NotNull(result);
        }

    }
}