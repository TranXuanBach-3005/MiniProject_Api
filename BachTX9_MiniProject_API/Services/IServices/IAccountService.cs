using BachTX9_MiniProject_API.DTOs.UserDtos;
using BachTX9_MiniProject_API.Helper;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Services.IServices
{
    public interface IAccountService
    {
        Task<ReponseMessage> Login(UserLoginDto userLoginDto);
        Task<string> Register(UserRegisterDto userRegisterDto);
        Task<string> RegisterTeacher(UserRegisterDto userRegisterDto);
        bool lockAccount(int id);
    }
}
