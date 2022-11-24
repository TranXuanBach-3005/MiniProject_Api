using AutoMapper;
using BachTX9_MiniProject_API.AutoMapper;
using BachTX9_MiniProject_API.DTOs.UserDtos;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Services;
using BachTX9_MiniProject_API.Services.IServices;
using BachTX9_MiniProject_API.UnitOfWorks;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BachTX9_TestMiniProject_API.TestServices
{
    public class AccountServiceTests
    {
        private readonly IAccountService accountService;
        //IUnitOfWork unitOfWork, IMapper mapper, CloudImageForBach cloudImageForBach
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        public AccountServiceTests()
        {
            mockUnitOfWork = new Mock<IUnitOfWork>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<Mapping>());
            var mapper = config.CreateMapper();
            accountService = new AccountService(mapper, mockUnitOfWork.Object );
        }
        [Fact]
        public async Task Resgiter_Test()
        {
            var userTest = new UserRegisterDto
            {
                UserName = "admin",
                Password="1111",
                Email ="b@gmail.com"
            };
            var user = new User
            {
                UserName = "admin",
                Password = "1111",
                Email = "b@gmail.com"
            };
            mockUnitOfWork.Setup(n => n.AccountRepository.CreateAsync(user));
            var result = await accountService.Register(userTest);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task ResgiterTeacher_Test()
        {
            var userTest = new UserRegisterDto
            {
                UserName = "admin",
                Password = "1111",
                Email = "b@gmail.com"
            };
            var user = new User
            {
                UserName = "admin",
                Password = "1111",
                Email = "b@gmail.com"
            };
            mockUnitOfWork.Setup(n => n.AccountRepository.CreateAsync(user));
            var result = await accountService.RegisterTeacher(userTest);
            Assert.NotNull(result);
        }
    }
}
