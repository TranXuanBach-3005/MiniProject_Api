using BachTX9_MiniProject_API.Repository;
using BachTX9_MiniProject_API.Repository.IRepository;
using System;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.UnitOfWorks
{
    public interface IUnitOfWork: IDisposable
    {
       
        IAccountRepository AccountRepository { get; }
        IUserRepository UserRepository { get; }
        ITestRepository TestRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IAnswerRepository AnswerRepository { get; }
        IUserTestRepository UserTestRepository { get; }
        void Save();
        Task<int> SavesChangeAsync();
        void BeginTransaction();
        void Commit();

    }
}
