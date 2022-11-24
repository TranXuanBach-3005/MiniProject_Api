using BachTX9_MiniProject_API.DTOs.Question;
using BachTX9_MiniProject_API.DTOs.Test;
using BachTX9_MiniProject_API.DTOs.UserTest;
using BachTX9_MiniProject_API.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IUserTestService _userTestService;
        public TeacherController(ITestService testService, IUserTestService userTestService)
        {
            _testService = testService;
            _userTestService = userTestService;
        }
        [HttpPost("CreateTest")]
        public async Task<IActionResult> CreateTest(AddTestDto addTestDto)
        {
            var result = await _testService.CreateTestAnync(addTestDto);
            return Ok(result);
        }
        [HttpPut("UpdateTest")]
        public async Task<IActionResult> UpdateTest(UpdateTestDto updateTestDto)
        {
           var result =  await _testService.UpdateTestAnync(updateTestDto);
            return Ok(result);
        }
        [HttpGet("GetAllTest")]
        public async Task<IActionResult> GetAllTest()
        {
            var result = await _testService.GetAllTestAnync();
            return Ok(result);
        }
        [HttpGet("GetTestId")]
        public  IActionResult GetTestId(int TestId)
        {
            var result =  _testService.GetTestByIdAnync(TestId);
            return Ok(result);
        }
        [HttpPost("CreateTestListQuestions")]
        public async Task<IActionResult> CreateTestQuestions(int testId,AddQuestionDto addQuestionDto)
        {
            var result = await _testService.CreateTestListQuestions(testId,addQuestionDto);
            return Ok(result);
        }
        [HttpPost("CreateScore")]
        public async Task<IActionResult> CreateScore(UserTestDto userTestDto)
        {
          var result =  await _userTestService.CreateUserTestAsync(userTestDto);
            return Ok(result);
        }
    }
}
