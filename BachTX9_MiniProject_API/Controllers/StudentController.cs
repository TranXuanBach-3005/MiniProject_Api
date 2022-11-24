using BachTX9_MiniProject_API.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IUserTestService _userTestService;
        public StudentController(ITestService testService, IUserTestService userTestService)
        {
            _testService = testService;
            _userTestService = userTestService;
        }
        [HttpGet("GetTestAndQuestion/{id}")]
        public async  Task<IActionResult> GetTestId(int id)
        {
           var result = await _testService.GetTestListQuestionAndAnswer(id);
            return Ok(result);
        }
        [HttpGet("GetTestScore")]
        public async Task<IActionResult> GetTestScoreId(int studentId, int testId)
        {
           var result = await _userTestService.GetUserTestById(studentId, testId);
            return Ok(result);
        }
        [HttpGet("GetTestCompleted/{studentId}")]
        public async Task<IActionResult> GetTestCompleted(int studentId)
        {
            var result = await _userTestService.GetListTestCompletedAsync(studentId);
            return Ok(result);
        }
        [HttpGet("GetTestNotCompleted/{studentId}")]
        public async Task<IActionResult> GetTestNotCompleted(int studentId)
        {
            var result = await _userTestService.GetListTestNotCompletedAsync(studentId);
            return Ok(result);
        }
    }
}
