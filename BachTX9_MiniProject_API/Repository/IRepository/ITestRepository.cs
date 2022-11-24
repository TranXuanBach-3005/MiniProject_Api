using BachTX9_MiniProject_API.DTOs.Test;
using BachTX9_MiniProject_API.Models;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Repository.IRepository
{
    public interface ITestRepository:IGenericRepository<Test>
    {
        Task<TestDto> GetTestListQuestionAndAnswer(int id);

    }
}
