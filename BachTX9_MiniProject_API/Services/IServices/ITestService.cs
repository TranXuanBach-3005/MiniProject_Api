using BachTX9_MiniProject_API.DTOs.Question;
using BachTX9_MiniProject_API.DTOs.Test;
using BachTX9_MiniProject_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Services.IServices
{
    public interface ITestService
    {
        Task<Test> CreateTestAnync(AddTestDto addTestDto);
        Task<Test> UpdateTestAnync(UpdateTestDto updateTestDto);
        Task<List<TestDto>> GetAllTestAnync();
        TestDto GetTestByIdAnync(int TestId);
        Task<string> CreateTestListQuestions(int testId,AddQuestionDto addQuestionDto);
        Task<TestDto> GetTestListQuestionAndAnswer(int id);
    }
}