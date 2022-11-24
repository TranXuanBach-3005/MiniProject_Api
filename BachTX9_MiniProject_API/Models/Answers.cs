using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Models
{
    public class Answers
    {
        [Key]
        public int AnsId { get; set; }
        public int  QuesId { get; set; }
        public string AnsBody { get; set; }
        public int IsTrue { get; set; }
        public string ImgUrl { get; set; }
        public Questions Questions { get; set; }
    }
}
