using AutoMapper;
using BachTX9_MiniProject_API.Data;
using BachTX9_MiniProject_API.DTOs.Question;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Repository
{
    public class QuestionRepository:GenericRepository<Questions>, IQuestionRepository
    {
        private readonly IMapper _mapper;
        public QuestionRepository(DataDbContext context, IMapper mapper) : base(context) 
        {
            _mapper = mapper;
        }

        public async Task CreateListQuestion(List<AddQuestionDto> addQuestionDtos)
        {
            var listTest = _mapper.Map<Questions>(addQuestionDtos);
            var result = await _context.AddAsync(listTest);
        }
    }
}
