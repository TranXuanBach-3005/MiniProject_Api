using BachTX9_MiniProject_API.DTOs.UserTest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Services.IServices
{
    public interface IUserTestService
    {
        Task<string> CreateUserTestAsync(UserTestDto userTestDto);
       Task<UserTestDto> GetUserTestById(int studentId, int testId);
        Task<List<UserTestDto>> GetListTestCompletedAsync(int studentId);
        Task<List<UserTestDto>> GetListTestNotCompletedAsync(int studentId);
    }
}
