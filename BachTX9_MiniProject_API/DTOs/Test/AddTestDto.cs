using BachTX9_MiniProject_API.DTOs.Question;
using System;
using System.Collections.Generic;

namespace BachTX9_MiniProject_API.DTOs.Test
{
    public class AddTestDto
    {
        public string TestName { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }
    }
}
