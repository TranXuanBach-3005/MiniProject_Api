using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Models
{
    public class Questions
    {
        [Key]
        public int QuesId { get; set; }
        public int TestId { get; set; }
        public string QuesBody { get; set; }
        public string ImgUrl { get; set; }
        public Test Test { get; set; }
        public ICollection<Answers> answers { get; set; }
    }
}
