using BachTX9_MiniProject_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Repository.IRepository
{
    public interface IUserTestRepository:IGenericRepository<UserTest>
    {
        Task<UserTest> GetUserTestAsync(int userId, int testId);
        Task<List<UserTest>> GetListTestCompletedAsync(int userId, bool isResult);
    }
}
