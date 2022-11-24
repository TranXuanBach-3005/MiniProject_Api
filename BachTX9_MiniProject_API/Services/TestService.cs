using AutoMapper;
using BachTX9_MiniProject_API.DTOs.Answers;
using BachTX9_MiniProject_API.DTOs.Question;
using BachTX9_MiniProject_API.DTOs.Test;
using BachTX9_MiniProject_API.JwtConfiguration;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Services.IServices;
using BachTX9_MiniProject_API.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CloudImageForBach _cloud;
        public TestService(IUnitOfWork unitOfWork, IMapper mapper, CloudImageForBach cloudImageForBach)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cloud = cloudImageForBach;
        }

        public async Task<Test> CreateTestAnync(AddTestDto addTestDto)
        {
            var test = _mapper.Map<Test>(addTestDto);
            await _unitOfWork.TestRepository.CreateAsync(test);
            await _unitOfWork.SavesChangeAsync();
            return test;
        }

        public async Task<string> CreateTestListQuestions(int testId, AddQuestionDto addQuestionDto)
        {
            //var answerDto = addQuestionDto.AddAnswerDto;
            _unitOfWork.BeginTransaction();
            var questionDto = new QuestionDto
            {
                TestId = testId,
                QuesBody = addQuestionDto.QuesBody,
                ImgUrl = await _cloud.UploadImage(addQuestionDto.ImgUrl)
            };
            var question = _mapper.Map<Questions>(questionDto);
            await _unitOfWork.QuestionRepository.CreateAsync(question);
            var rowsEffectedQuestion=await _unitOfWork.SavesChangeAsync();

            var listAnswer = addQuestionDto.AddAnswerDto;
            var answer = listAnswer.Select(x => _mapper.Map<AddAnswerDto, Answers>(x)).ToList();
            for(int i=0;i<answer.Count();i++)
            {
                answer[i].QuesId = question.QuesId;
            }
            _unitOfWork.AnswerRepository.CreateRange(answer);
            var rowsEffectedAnswer = await _unitOfWork.SavesChangeAsync();
            if(rowsEffectedQuestion>0&& rowsEffectedAnswer>0)
            {
                _unitOfWork.Commit();
                return "Success";
            }
            return "Failed";
        }

        public async Task<List<TestDto>> GetAllTestAnync()
        {
            var result = await _unitOfWork.TestRepository.GetAllAsync();
            var test = _mapper.Map<List<TestDto>>(result);
            return test;
        }

        public TestDto GetTestByIdAnync(int TestId)
        {
            var result = _unitOfWork.TestRepository.GetById(TestId);
            var test = _mapper.Map<TestDto>(result);
            return test;
        }

        public async Task<TestDto> GetTestListQuestionAndAnswer(int id)
        {
            var result = await _unitOfWork.TestRepository.GetTestListQuestionAndAnswer(id);
            return result;
        }

        public async Task<Test> UpdateTestAnync(UpdateTestDto updateTestDto)
        {
            var result = _unitOfWork.TestRepository.GetById(updateTestDto.TestId);
            result.TestName = updateTestDto.TestName;
            result.Scores = updateTestDto.Scores;
            result.Description = updateTestDto.Description;
            result.Duration = updateTestDto.Duration;
            var test = _mapper.Map<Test>(result);
            _unitOfWork.TestRepository.Update(test);
            await _unitOfWork.SavesChangeAsync();
            return test;
        }
    }
}
