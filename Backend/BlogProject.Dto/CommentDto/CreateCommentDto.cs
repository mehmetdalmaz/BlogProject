using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Dto.CommentDto
{
    public class CreateCommentDto
    {
        public string? Content { get; set; } // Yorum içeriği
        public int PostId { get; set; }     // Hangi yazıya yapıldığı
        public int UserId { get; set; }     // Yorumu yapan kullanıcı (Opsiyonel olabilir, JWT'den alınabilir)
    }
}