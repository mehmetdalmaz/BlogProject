using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BlogProject.Entity.Models
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; } // Kullanıcının tam adı
        public string? ProfilePictureUrl { get; set; } // Kullanıcı profil fotoğrafı

        // Kullanıcının yazıları, yorumları ve beğenileri
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Like>? Likes { get; set; }
    }
}