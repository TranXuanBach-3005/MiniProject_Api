using AutoMapper;
using BachTX9_MiniProject_API.AutoMapper;
using BachTX9_MiniProject_API.DTOs.UserTest;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Services;
using BachTX9_MiniProject_API.Services.IServices;
using BachTX9_MiniProject_API.UnitOfWorks;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BachTX9_TestMiniProject_API.TestServices
{
    public class UserTestServiceTests
    {
        private readonly IUserTestService userTestService;
        //IUnitOfWork unitOfWork, IMapper mapper, CloudImageForBach cloudImageForBach
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        public UserTestServiceTests()
        {
            mockUnitOfWork = new Mock<IUnitOfWork>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<Mapping>());
            var mapper = config.CreateMapper();
            userTestService = new UserTestService(mapper, mockUnitOfWork.Object);
        }
        [Fact]
        public async Task CreateUserTestAsync_test()
        {
            var usertest = new UserTest
            {
                IsComplete = false,
                Scores = 5
            };
            var usertestdto = new UserTestDto
            {
                IsComplete = false,
                Scores = 5
            };
            mockUnitOfWork.Setup(n => n.UserTestRepository.CreateAsync(usertest));
            var result = await userTestService.CreateUserTestAsync(usertestdto);
            Assert.Equal("Success", result);

        }
        [Fact]
        public async Task GetUserTestById_test()
        {
            var mockDto = new UserTest
            {
                IsComplete = true,
                Scores = 8
            };
            mockUnitOfWork.Setup(x => x.UserTestRepository
                .GetUserTestAsync(1,1)).ReturnsAsync(mockDto);
            var result = await userTestService.GetUserTestById(1,1);
            // asserrt
            Assert.Equal(mockDto.Scores, (object)result.Scores);
        }
        [Fact]
        public async Task GetListTestCompletedAsync_test()
        {
            var mokDto = new List<UserTest>
            {
                new UserTest
                {
                    IsComplete = true,
                },
                 new UserTest
                {
                    IsComplete = false,
                }
            };
            mockUnitOfWork.Setup(x => x.UserTestRepository.GetListTestCompletedAsync(1, true)).ReturnsAsync(mokDto);
            var result = await userTestService.GetListTestCompletedAsync(1);
            Assert.Equal(mokDto[0].IsComplete, (object)result[0].IsComplete);
        }
    }
}
