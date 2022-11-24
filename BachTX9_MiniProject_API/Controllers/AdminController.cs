using BachTX9_MiniProject_API.DTOs.User;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly ITestService _testService;
        private readonly IMemoryCache _cache;
        public AdminController(IAdminService adminService, ITestService testService, IMemoryCache cache)
        {
            _adminService = adminService;
            _testService = testService;
            _cache = cache;
        }
        [HttpGet("GetAllStudent")]
        public async Task<IActionResult> GetAllStudent()
        {
            var cacheKey = "GetAllStudent";
            if(_cache.TryGetValue(cacheKey,out IEnumerable<User> result ))
            {
                return Ok(new
                {
                    message = " List Student",
                    Success = "200",
                    result
                });
            }
            result = await _adminService.GetAllStudent();
            var cachEntryOptions = new MemoryCacheEntryOptions()
                                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
            _cache.Set(cacheKey, result, cachEntryOptions);
            return Ok(new
            {
                message = " List Student",
                Success = "200",
                result
            });
        }
        [HttpGet("GetAllTeacher")]
        public async Task<IActionResult> GetAllTeacher()
        {
            var result = await _adminService.GetAllTeacher();
            return Ok(new
            {
                message = " List Teacher",
                Success = "200",
                result
            });
        }
        [HttpGet("GetAllTest")]
        public async Task<IActionResult> GetAllTest()
        {
            var result = await _testService.GetAllTestAnync();
            return Ok(result);
        }
        [HttpGet("GetTestAndQuestion")]
        public async Task<IActionResult> GetTestAndQuestion(int id)
        {
            var result = await _testService.GetTestListQuestionAndAnswer(id);
            return Ok(result);
        }
        [HttpDelete("DeleteUser")]
        public IActionResult Delete( int id)
        {
            _adminService.Delete(id);
            return Ok(new { 
                message ="success",
            });

        }
        [HttpPut("UpdateUser")]
        public IActionResult Update( UserUpdateDto user)
        {
            _adminService.Update(user);
            return Ok(new
            {
                message = "success",
            }) ;
        }
    }
}
