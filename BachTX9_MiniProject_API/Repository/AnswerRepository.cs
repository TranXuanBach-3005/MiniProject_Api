using BachTX9_MiniProject_API.Data;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Repository.IRepository;

namespace BachTX9_MiniProject_API.Repository
{
    public class AnswerRepository:GenericRepository<Answers>, IAnswerRepository
    {
        public AnswerRepository(DataDbContext context) : base(context) { }
    }
}
