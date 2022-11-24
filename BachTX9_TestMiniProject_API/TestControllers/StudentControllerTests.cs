using BachTX9_MiniProject_API.Controllers;
using BachTX9_MiniProject_API.DTOs.Test;
using BachTX9_MiniProject_API.DTOs.UserTest;
using BachTX9_MiniProject_API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BachTX9_TestMiniProject_API
{
    public class StudentControllerTests
    {
        private readonly StudentController _studentController;
        private readonly Mock<ITestService> _mockTestService;
        private readonly Mock<IUserTestService> _mockUserTestService;
        public StudentControllerTests()
        {
            _mockTestService = new Mock<ITestService>();
            _mockUserTestService = new Mock<IUserTestService>();
            _studentController = new StudentController(_mockTestService.Object,
            _mockUserTestService.Object);
        }
        [Fact]
        public async Task GetTestId_Test()
        {
            var testTest = new TestDto
            {
                TestName = "Kt1"
            };
            _mockTestService.Setup(n => n.GetTestListQuestionAndAnswer(1)).ReturnsAsync(testTest);
            var result = await _studentController.GetTestId(1);
            Assert.Equal(testTest, ((ObjectResult)result).Value);
        }
        [Fact]
        public async Task GetTestScoreId()
        {
            var testTest = new UserTestDto
            {
                Scores = 5,
                IsComplete = true
            };
            _mockUserTestService.Setup(n => n.GetUserTestById(1,1)).ReturnsAsync(testTest);
            var result = await _studentController.GetTestScoreId(1,1);
            Assert.Equal(testTest, ((ObjectResult)result).Value);
        }
        [Fact]
        public async Task GetTestCompleted()
        {
            var testTest = new List<UserTestDto>
            {
                new UserTestDto
                {
                    Scores = 5,
                    IsComplete = false
                },
                new UserTestDto
                {
                    Scores = 8,
                    IsComplete = true
                }
            };
            _mockUserTestService.Setup(n => n.GetListTestCompletedAsync(1)).ReturnsAsync(testTest);
            var result = await _studentController.GetTestCompleted(1);
            Assert.Equal(testTest, ((ObjectResult)result).Value);
        }
        [Fact]
        public async Task GetTestNotCompleted()
        {
            var testTest = new List<UserTestDto>
            {
                new UserTestDto
                {
                    Scores = 5,
                    IsComplete = false
                },
                new UserTestDto
                {
                    Scores = 8,
                    IsComplete = true
                }
            };
            _mockUserTestService.Setup(n => n.GetListTestNotCompletedAsync(1)).ReturnsAsync(testTest);
            var result = await _studentController.GetTestNotCompleted(1);
            Assert.Equal(testTest, ((ObjectResult)result).Value);
        }
    }
}
