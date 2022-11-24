using AutoMapper;
using BachTX9_MiniProject_API.AutoMapper;
using BachTX9_MiniProject_API.Enums;
using BachTX9_MiniProject_API.JwtConfiguration;
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
    public class AdminServiceTests
    {
        private readonly IAdminService adminService;
        //IUnitOfWork unitOfWork, IMapper mapper, CloudImageForBach cloudImageForBach
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        public AdminServiceTests()
        {
            mockUnitOfWork = new Mock<IUnitOfWork>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<Mapping>());
            var mapper = config.CreateMapper();
            adminService = new AdminService(mockUnitOfWork.Object,
                mapper);
        }
        [Fact]
        public async Task GetAllStudent_test()
        {
            var userTest = new List<User>
            {
                new User
                {
                    UserName = "admin",
                    Role = RoleEnum.Admin
                },
                new User
                {
                    UserName = "teacher",
                    Role = RoleEnum.Teacher
                }
            };
            mockUnitOfWork.Setup(n => n.UserRepository.GetAllStudentAsync()).ReturnsAsync(userTest);
            var result =await adminService.GetAllStudent();
            Assert.Equal(userTest, result);
        }
        [Fact]
        public async Task GetAllTeacher_test()
        {
            var userTest = new List<User>
            {
                new User
                {
                    UserName = "admin",
                    Role = RoleEnum.Admin
                },
                new User
                {
                    UserName = "teacher",
                    Role = RoleEnum.Teacher
                }
            };
            mockUnitOfWork.Setup(n => n.UserRepository.GetAllTeacherAsync()).ReturnsAsync(userTest);
            var result = await adminService.GetAllTeacher();
            Assert.Equal(userTest, result);
        }
    }
}
