using AutoMapper;
using BachTX9_MiniProject_API.AutoMapper;
using BachTX9_MiniProject_API.DTOs.Test;
using BachTX9_MiniProject_API.JwtConfiguration;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Services;
using BachTX9_MiniProject_API.Services.IServices;
using BachTX9_MiniProject_API.UnitOfWorks;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
namespace BachTX9_TestMiniProject_API
{
    public class TestServiceTests
    {
        private readonly ITestService testService;
        //IUnitOfWork unitOfWork, IMapper mapper, CloudImageForBach cloudImageForBach
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly Mock<CloudImageForBach> mockClound;
        public TestServiceTests()
        {
            mockUnitOfWork = new Mock<IUnitOfWork>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<Mapping>());
            var mapper = config.CreateMapper();
            mockClound = new Mock<CloudImageForBach>();
            testService = new TestService(mockUnitOfWork.Object,
                mapper, mockClound.Object);
        }
        [Fact]
        public async Task GetTestListQuestionAndAnswer_test()
        {
            var mockDto = new TestDto
            {
                Description = "hihi"
            };
            mockUnitOfWork.Setup(x => x.TestRepository
                .GetTestListQuestionAndAnswer(1)).ReturnsAsync(mockDto);
            var result = await testService.GetTestListQuestionAndAnswer(1);
            // asserrt
            Assert.Equal("hihi", result.Description);
        }
        [Fact]
        public void GetTestByIdAnync_Test()
        {
            var mockDto = new Test
            {
                Description = "hihi"
            };
            mockUnitOfWork.Setup(x => x.TestRepository
                .GetById(1)).Returns(mockDto);
            var result =  testService.GetTestByIdAnync(1);
            // asserrt
            Assert.Equal("hihi", result.Description);
        }
        [Fact]
        public async Task CreateTestAnync_test()
        {
            var testTest = new AddTestDto
            {
                TestName = "kt1"
            };
            var test = new Test
            {
                TestName = "kt1"
            };
            mockUnitOfWork.Setup(x => x.TestRepository.CreateAsync(test));
            var result = await testService.CreateTestAnync(testTest);
            Assert.Equal(testTest.TestName, result.TestName);
        }
        [Fact]
        public async Task GetAllTestAnync_test()
        {
            var listTest = new List<Test>
            {
                new Test
                {
                    TestName = "kt1"
                },
                new Test
                {
                    TestName = "kt2"
                }
            };
            mockUnitOfWork.Setup(n => n.TestRepository.GetAllAsync()).ReturnsAsync(listTest);
            var result = await testService.GetAllTestAnync();
            Assert.NotNull((object)result);
        }
    }
}
