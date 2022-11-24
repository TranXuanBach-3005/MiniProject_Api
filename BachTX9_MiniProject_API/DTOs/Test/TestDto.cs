using BachTX9_MiniProject_API.DTOs.Question;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.DTOs.Test
{
    public class TestDto
    {
        [Key]
        public int TestId { get; set; }
        [Required]
        public string TestName { get; set; }
        [Required]
        public int Scores { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Duration { get; set; }
        public List<QuestionDto> questions { get; set; }
    }
}
