using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Models
{
    public class UserTest
    {
        public int UserId { get; set; }
        public User user { get; set; }
        public int TestId { get; set; }
        public Test test { get; set; }
        public bool IsComplete { get; set; }
        public int Scores { get; set; }
        [Key]
        public int UserTestId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
