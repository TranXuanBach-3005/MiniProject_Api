using AutoMapper;
using BachTX9_MiniProject_API.Data;
using BachTX9_MiniProject_API.DTOs.Test;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Repository
{
    public class TestRepository:GenericRepository<Test>, ITestRepository
    {
        private readonly IMapper _mapper;
        public TestRepository(DataDbContext context, IMapper mapper) : base(context) 
        {
            _mapper = mapper;
        }
        public async Task<TestDto> GetTestListQuestionAndAnswer(int id)
        {
            var result = await _context.tests.Include(n => n.questions)
                .ThenInclude(q => q.answers)
                .FirstOrDefaultAsync(x => x.TestId == id);
            var listTest = _mapper.Map<TestDto>(result);
            return listTest;
        }
    }
}
