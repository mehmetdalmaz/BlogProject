using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Dto.PostDto
{
    public class CreatePostDto
    {
        public string? Title { get; set; }        // Yazı başlığı
        public string? Content { get; set; }      // Yazı içeriği
        public int CategoryId { get; set; }
    }
}