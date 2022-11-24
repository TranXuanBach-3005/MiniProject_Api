using BachTX9_MiniProject_API.Controllers;
using BachTX9_MiniProject_API.DTOs.Question;
using BachTX9_MiniProject_API.DTOs.Test;
using BachTX9_MiniProject_API.DTOs.UserTest;
using BachTX9_MiniProject_API.Models;
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
    public class TeacherControllerTests
    {
        private readonly TeacherController _teacherController;
        private readonly Mock<ITestService> _mockTestService;
        private readonly Mock<IUserTestService> _mockUserTestService;
        public TeacherControllerTests()
        {
            _mockTestService = new Mock<ITestService>();
            _mockUserTestService = new Mock<IUserTestService>();
            _teacherController = new TeacherController(_mockTestService.Object,
            _mockUserTestService.Object);
        }
        [Fact]
        public async Task CreateTest_Test()
        {
            var testTest = new AddTestDto
            {
                TestName = "Kt1"
            };
            var test = new Test
            {
                TestName = "Kt1"
            };
            _mockTestService.Setup(n => n.CreateTestAnync(testTest)).ReturnsAsync(test);
            var result = await _teacherController.CreateTest(testTest);
            Assert.Equal(test, ((ObjectResult)result).Value);
        }
        [Fact]
        public async Task UpdateTest_Test()
        {
            var testTest = new UpdateTestDto
            {
                TestName = "Kt1"
            };
            var test = new Test
            {
                TestName = "Kt2"
            };
            _mockTestService.Setup(n => n.UpdateTestAnync(testTest)).ReturnsAsync(test);
            var result = await _teacherController.UpdateTest(testTest);
            Assert.Equal(test, ((ObjectResult)result).Value);
        }
        [Fact]
        public async Task GetAllTest_Test()
        {
            var testTest = new List<TestDto>
            {
                new TestDto
                {
                    TestName = "kt1"
                },
                new TestDto
                {
                    TestName = "kt2"
                }
            };
            _mockTestService.Setup(n => n.GetAllTestAnync()).ReturnsAsync(testTest);
            var result = await _teacherController.GetAllTest();
            Assert.Equal(testTest, ((ObjectResult)result).Value);
        }
        [Fact]
        public void GetTestId_Test()
        {
            var testTest = new TestDto
            {
                TestName = "kt1"
            };
            _mockTestService.Setup(n => n.GetTestByIdAnync(1)).Returns(testTest);
            var result = _teacherController.GetTestId(1);
            Assert.Equal(testTest, ((ObjectResult)result).Value);
        }
        [Fact]
        public async Task CreateTestQuestions_Test()
        {
            var testList = new AddQuestionDto
            {
                QuesBody ="cauhoi1",
                ImgUrl ="img"
            };
            _mockTestService.Setup(n => n.CreateTestListQuestions(1, testList)).ReturnsAsync("success");
            var result = await _teacherController.CreateTestQuestions(1, testList);
            Assert.Equal("success", ((ObjectResult)result).Value);
        }
        [Fact]
        public async Task CreateScore()
        {
            var testList = new UserTestDto
            {
               Scores = 5,
               IsComplete = false
            };
            _mockUserTestService.Setup(n => n.CreateUserTestAsync(testList)).ReturnsAsync("success");
            var result = await _teacherController.CreateScore(testList);
            Assert.Equal("success", ((ObjectResult)result).Value);
        }

    }
}
