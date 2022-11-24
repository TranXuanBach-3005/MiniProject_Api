using BachTX9_MiniProject_API.DTOs.UserDtos;
using BachTX9_MiniProject_API.Models;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Repository.IRepository
{
    public interface IAccountRepository:IGenericRepository<User>
    {
        Task<string> Login(UserLoginDto userLoginDto);
        Task<User> Authenticate(UserLoginDto userLoginDto);
        string GenereateJwtTonken(User user);
        Task<User> GetByUserName(string userName, string Password);
        bool lockAccount(int id);
    }
}
