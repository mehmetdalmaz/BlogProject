using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Data.Abstract;
using BlogProject.Data.Context;
using BlogProject.Data.Repository;
using BlogProject.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Data.EnitityFramework
{
    public class EfPostDal : GenericRepository<Post>, IPostDal
    {

        private readonly BlogContext _context;
        public EfPostDal(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<Post> GetMostCommentedPosts()
        {
            return _context.Posts
                    .Include(p => p.Comments)
                    .OrderByDescending(p => p.Comments != null ? p.Comments.Count : 0)
                    .Take(10)
                    .ToList();
        }


        public List<Post> GetPopularPosts()
        {
            return _context.Posts
            .Include(p => p.Likes)
            .OrderByDescending(p => p.Likes != null ? p.Likes.Count : 0)
            .Take(10)
            .ToList();


        }

        public List<Post> GetPostsByCategory(int categoryId)
        {
            return _context.Posts
            .Where(p => p.CategoryId == categoryId)
            .ToList();
        }

        public List<Post> GetPostsByUser(Guid userId)
        {
            return _context.Posts
            .Where(p => p.UserId == userId)
            .ToList();
        }

        public List<Post> GetRecentPosts(DateTime afterDate)
        {
            return _context.Posts
            .Where(p => p.CreatedAt > afterDate)
            .ToList();
        }

        public List<Post> SearchPosts(string keyword)
        {
            return _context.Posts
          .Where(p => (p.Title ?? "").Contains(keyword) || (p.Content ?? "").Contains(keyword))
          .ToList();
        }
    }
}
