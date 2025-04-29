using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Dto.LikeDto
{
    public class ResultLikeDto
    {
        public int Id { get; set; }
        public int PostId { get; set; } // Beğenilen yazı
        public Guid UserId { get; set; } // Beğeni yapan kullanıcı
    }
}