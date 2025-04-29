using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Dto.LikeDto
{
    public class UpdateLikeDto
    {
        
        public int Id { get; set; }
        public int PostId { get; set; } 
        public Guid UserId { get; set; } 
    }
}