using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Entity.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int PostId { get; set; } // Beğenilen yazı
        public Post? Post { get; set; } // Yazıya ait referans
        public Guid UserId { get; set; } // Beğeni yapan kullanıcı
        public AppUser? User { get; set; } // Kullanıcıya ait referans
    }
}