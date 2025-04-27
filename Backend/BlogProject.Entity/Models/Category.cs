using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Entity.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; } // Kategori adı
        public string? Description { get; set; } // Kategori açıklaması

        // Bir kategori birden fazla yazıya sahip olabilir
        public ICollection<Post>? Posts { get; set; }
    }
}