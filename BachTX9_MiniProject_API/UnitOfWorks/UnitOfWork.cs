using BachTX9_MiniProject_API.Data;
using BachTX9_MiniProject_API.Repository;
using BachTX9_MiniProject_API.Repository.IRepository;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataDbContext _context;

        public UnitOfWork(DataDbContext context, IAccountRepository accountRepository,
            IUserRepository userRepository, ITestRepository testRepository,
            IQuestionRepository questionRepository, IAnswerRepository answerRepository,
            IUserTestRepository userTestRepository)
        {
            _context = context;
            AccountRepository = accountRepository;
            UserRepository = userRepository;
            TestRepository = testRepository;
            QuestionRepository = questionRepository;
            AnswerRepository = answerRepository;
            UserTestRepository = userTestRepository;
        }
        public IAccountRepository AccountRepository { get; }
        public IUserRepository UserRepository { get; }
        public ITestRepository TestRepository { get; }
        public IQuestionRepository QuestionRepository { get; }
        public IAnswerRepository AnswerRepository { get; }
        public IUserTestRepository UserTestRepository { get; }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SavesChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }
        public void Commit()
        {
            _context.Database.CommitTransaction();
        }
    }
}
