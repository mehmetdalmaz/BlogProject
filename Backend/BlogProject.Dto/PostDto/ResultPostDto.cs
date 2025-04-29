using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Dto.PostDto
{
    public class ResultPostDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; } 
        public Guid UserId { get; set; } 
    }
}