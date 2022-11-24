using BachTX9_MiniProject_API.DTOs.Answers;
using System.Collections.Generic;

namespace BachTX9_MiniProject_API.DTOs.Question
{
    public class QuestionDto
    {
        public int TestId { get; set; }
        public string QuesBody { get; set; }
        public string ImgUrl { get; set; }
        public List<AnswerNotTrueDto> answers { get; set; }
    }
}
