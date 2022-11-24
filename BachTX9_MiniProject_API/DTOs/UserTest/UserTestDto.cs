using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.DTOs.UserTest
{
    public class UserTestDto
    {
        public int UserId { get; set; }
        public int TestId { get; set; }
        public int Scores { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
