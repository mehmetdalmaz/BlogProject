using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Entity.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; } // Yorum içeriği
        public DateTime CreatedAt { get; set; } // Yorum tarihi
        public int PostId { get; set; } // Yorum yapılan yazı
        public Post? Post { get; set; } // Yazıya ait referans
        public int UserId { get; set; } // Yorum yapan kullanıcı
        public AppUser? User { get; set; } // Kullanıcıya ait referan
    }
}