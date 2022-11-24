using BachTX9_MiniProject_API.DTOs.UserDtos;
using BachTX9_MiniProject_API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var result = await _accountService.Register(userRegisterDto);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task <IActionResult> Login(UserLoginDto userLoginDto)
        {
            var result = await _accountService.Login(userLoginDto);
            return Ok(result);
        }
        [HttpPost("RegisterTeachere")]
        public async Task<IActionResult> RegisterTeacher(UserRegisterDto userRegisterDto)
        {
            var result = await _accountService.RegisterTeacher(userRegisterDto);
            return Ok(result);
        }
        [HttpPost("LockAccount")]
        public IActionResult LockUser(int id)
        {
            var result = _accountService.lockAccount(id);
            if (result == true)
            {
                return Ok(new
                {
                    message = "Success"
                });
            }
            else
            {
                return Ok(new
                {
                    message = "Not Success"
                });
            }
        }
    }
}
