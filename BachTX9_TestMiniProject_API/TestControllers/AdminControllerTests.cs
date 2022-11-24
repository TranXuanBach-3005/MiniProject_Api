using BachTX9_MiniProject_API.Controllers;
using BachTX9_MiniProject_API.DTOs.Test;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BachTX9_TestMiniProject_API
{
    public class AdminControllerTests
    {
        private readonly AdminController _adminController;
        private readonly Mock<IAdminService> _mockAdminService;
        private readonly Mock<ITestService> _mockTestService;
        private readonly Mock<IMemoryCache> _mockCache;
        public AdminControllerTests()
        {
            _mockAdminService = new Mock<IAdminService>();
            _mockTestService = new Mock<ITestService>();
            _mockCache = new Mock<IMemoryCache>();
            _adminController = new AdminController(_mockAdminService.Object,
                _mockTestService.Object, _mockCache.Object);
        }
        [Fact]
        public async Task GetAllTeacher_Test()
        {
            var teacherTest = new List<User>
            {
                new User
            {
                UserName = "hiteacher"
            },
                  new User
            {
                UserName = "hiteacher2"
            },
            };
            _mockAdminService.Setup(x => x.GetAllTeacher()).ReturnsAsync(teacherTest);
            var result = await _adminController.GetAllTeacher();
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetAllStudent_Test()
        {
            var studentTest = new List<User>
            {
                new User
            {
                UserName = "hiteacher"
            },
                  new User
            {
                UserName = "hiteacher2"
            },
            };
            _mockAdminService.Setup(x => x.GetAllStudent()).ReturnsAsync(studentTest);
            var result = await _adminController.GetAllTeacher();
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task TestGetAll_Test()
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
            },
            };
            _mockTestService.Setup(n => n.GetAllTestAnync()).ReturnsAsync(testTest);
            var result = await _adminController.GetAllTeacher();
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetTestAndQuestion_Test()
        {
            var testTest = new TestDto
            {
                TestName = "kt"
            };
            _mockTestService.Setup(n => n.GetTestListQuestionAndAnswer(1)).ReturnsAsync(testTest);
            var result = await _adminController.GetTestAndQuestion(1);
            Assert.Equal(testTest, ((ObjectResult)result).Value);
        }
    }
}
