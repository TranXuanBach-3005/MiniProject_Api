using BachTX9_MiniProject_API.Enums;
using BachTX9_MiniProject_API.Models;
using Microsoft.EntityFrameworkCore;
namespace BachTX9_MiniProject_API.Data
{
    public static class SeedData
    {
        public static void SeedAllData(this ModelBuilder modelbuild)
        {
          
            modelbuild.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "admin",
                    Password = "123456",
                    Email =" n@gmail.com",
                    Role = RoleEnum.Admin
                },
                  new User
                  {
                      UserId = 2,
                      UserName = "teacherA",
                      Password = "123456",
                      Email = " n@gmail.com",
                      Role = RoleEnum.Teacher
                  },
                 new User
                 {
                     UserId = 3,
                     UserName = "studentA",
                     Email = " n@gmail.com",
                     Password = "123456",
                     Role = RoleEnum.Student
                 }
                );
            modelbuild.Entity<Test>().HasData(
                new Test
                {
                    TestId = 1,
                    TestName = "Final C#",
                    Description = "Bai kiem tra 1",
                },
                new Test
                {
                    TestId = 2,
                    TestName = "Final Sql",
                    Description = "Bai kiem tra 1"
                },
                new Test
                {
                    TestId = 3,
                    TestName = "Final Web Api",
                    Description = "Bai kiem tra 1"
                }
                );
            modelbuild.Entity<UserTest>().HasData(
                new UserTest
                {
                    UserTestId = 1,
                    UserId = 1,
                    TestId = 1,
                    Scores = 10,
                    IsComplete = true
                },
                new UserTest
                {
                    UserTestId = 2,
                    UserId = 2,
                    TestId = 2,
                    Scores = 9,
                    IsComplete = true
                },
                new UserTest
                {
                    UserTestId = 3,
                    UserId = 3,
                    TestId = 3,
                    Scores = 5,
                    IsComplete = true
                }
                );
            modelbuild.Entity<Questions>().HasData(
                new Questions
                {
                    QuesId = 1,
                    TestId = 1,
                    QuesBody = "1 + 1",
                    ImgUrl = "",
                },
                new Questions
                {
                    QuesId = 2,
                    TestId = 2,
                    QuesBody = "1 + 2",
                    ImgUrl = "",
                },
                new Questions
                {
                    QuesId = 3,
                    TestId =3,
                    QuesBody = "1 + 3",
                    ImgUrl = "",
                }
                );
            modelbuild.Entity<Answers>().HasData(
                //question 1
                new Answers
                {
                    AnsId = 1,
                    QuesId = 1,
                    AnsBody = "1",
                    ImgUrl = "",
                    IsTrue = 1
                },
                new Answers
                {
                    AnsId = 2,
                    QuesId = 1,
                    AnsBody = "2",
                    ImgUrl = "",
                    IsTrue = 0
                },
                new Answers
                {
                    AnsId = 3,
                    QuesId = 1,
                    AnsBody = "3",
                    ImgUrl = "",
                    IsTrue = 0
                },
                new Answers
                {
                    AnsId = 4,
                    QuesId = 1,
                    AnsBody = "4",
                    ImgUrl = "",
                    IsTrue = 1
                },
                //question 2
                new Answers
                {
                    AnsId = 5,
                    QuesId = 2,
                    AnsBody = "1",
                    ImgUrl = "",
                    IsTrue = 0
                },
                new Answers
                {
                    AnsId = 6,
                    QuesId = 2,
                    AnsBody = "2",
                    ImgUrl = "",
                    IsTrue = 1
                },
                new Answers
                {
                    AnsId = 7,
                    QuesId = 2,
                    AnsBody = "3",
                    ImgUrl = "",
                    IsTrue = 0
                },
                new Answers
                {
                    AnsId = 8,
                    QuesId = 2,
                    AnsBody = "4",
                    ImgUrl = "",
                    IsTrue = 1
                },
                //question 3
                new Answers
                {
                    AnsId = 9,
                    QuesId = 3,
                    AnsBody = "1",
                    ImgUrl = "",
                    IsTrue = 1
                },
                new Answers
                {
                    AnsId = 10,
                    QuesId = 3,
                    AnsBody = "2",
                    ImgUrl = "",
                    IsTrue = 0
                },
                new Answers
                {
                    AnsId = 11,
                    QuesId = 3,
                    AnsBody = "3",
                    ImgUrl = "",
                    IsTrue = 0
                },
                new Answers
                {
                    AnsId = 12,
                    QuesId = 3,
                    AnsBody = "4",
                    ImgUrl = "",
                    IsTrue = 1
                }
                );
        }
    }
}
