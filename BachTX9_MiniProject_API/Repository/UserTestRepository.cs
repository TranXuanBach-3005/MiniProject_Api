using AutoMapper;
using BachTX9_MiniProject_API.Data;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Repository
{
    public class UserTestRepository : GenericRepository<UserTest>, IUserTestRepository
    {
        private readonly IMapper _mapper;
        public UserTestRepository(DataDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<UserTest> GetUserTestAsync(int userId, int testId)
        {
            var userTest = await _context.userTests.FirstOrDefaultAsync(n => n.UserId == userId && n.TestId == testId);
            return userTest;
        }
        public async Task<List<UserTest>> GetListTestCompletedAsync(int userId, bool isResult)
        {
            var test = await _context.userTests
                .Where(n => n.UserId == userId && n.IsComplete == isResult)
                .ToListAsync();
            return test;

        }
    }
}
