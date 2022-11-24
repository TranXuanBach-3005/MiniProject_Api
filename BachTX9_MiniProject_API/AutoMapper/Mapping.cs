using AutoMapper;
using BachTX9_MiniProject_API.DTOs;
using BachTX9_MiniProject_API.DTOs.Answers;
using BachTX9_MiniProject_API.DTOs.Question;
using BachTX9_MiniProject_API.DTOs.Test;
using BachTX9_MiniProject_API.DTOs.User;
using BachTX9_MiniProject_API.DTOs.UserDtos;
using BachTX9_MiniProject_API.DTOs.UserTest;
using BachTX9_MiniProject_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserRegisterDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            
            CreateMap<Test, TestDto>().ReverseMap();
            CreateMap<Test, AddTestDto>().ReverseMap();
            CreateMap<Test, UpdateTestDto>().ReverseMap();

            CreateMap<Answers, AddAnswerDto>().ReverseMap();
            CreateMap<Answers, AnswerDto>().ReverseMap();
            CreateMap<Answers, AnswerNotTrueDto>().ReverseMap();

            CreateMap<Questions, AddQuestionDto>().ReverseMap();
            CreateMap<Questions, QuestionDto>().ReverseMap();

            CreateMap<UserTest, UserTestDto>().ReverseMap();
        }
    }
}
