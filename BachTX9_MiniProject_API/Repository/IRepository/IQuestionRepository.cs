using BachTX9_MiniProject_API.DTOs.Question;
using BachTX9_MiniProject_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Repository.IRepository
{
    public interface IQuestionRepository:IGenericRepository<Questions>
    {
        Task CreateListQuestion(List<AddQuestionDto> addQuestionDtos);

    }
}
