using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Entity.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; } 
        public string? Content { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public Guid UserId { get; set; } 
        public AppUser? User { get; set; } 
        public int CategoryId { get; set; }
        public Category? Category { get; set; } 

        // Yorumlar ve beğeniler
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Like>? Likes { get; set; }
    }
}