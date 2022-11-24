using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.DTOs.Test
{
    public class UpdateTestDto
    {
        [Key]
        public int TestId { get; set; }
        public string TestName { get; set; }
        public int Scores { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }
    }
}
