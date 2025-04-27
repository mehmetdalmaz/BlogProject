using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Entity.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; } // Yazı başlığı
        public string? Content { get; set; } // Yazı içeriği
        public DateTime CreatedAt { get; set; } // Yazı oluşturulma tarihi
        public int UserId { get; set; } // Yazıyı yazan kullanıcı
        public AppUser? User { get; set; } // Kullanıcıya ilişkin bilgi
                                           // Kategoriye ait ilişki
        public int CategoryId { get; set; }
        public Category? Category { get; set; } // Kategori referansı

        // Yorumlar ve beğeniler
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Like>? Likes { get; set; }
    }
}