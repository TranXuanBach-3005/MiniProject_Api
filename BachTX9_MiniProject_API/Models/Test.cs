using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Models
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }
        public string TestName { get; set; }
        public int Scores { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }
        public ICollection<UserTest> userTests { get; set; }
        public ICollection<Questions> questions { get; set; }
    }
}
