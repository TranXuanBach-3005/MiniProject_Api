using BachTX9_MiniProject_API.DTOs.Answers;
using System.Collections.Generic;

namespace BachTX9_MiniProject_API.DTOs.Question
{
    public class AddQuestionDto
    {
        public string QuesBody { get; set; }
        public string ImgUrl { get; set; }
        public List<AddAnswerDto> AddAnswerDto { get; set; }
    }
}
