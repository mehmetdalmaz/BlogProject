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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly BlogContext _blogcontext;
        public EfCategoryDal(BlogContext context) : base(context)
        {
            _blogcontext = context;
        }

        public Category GetCategoryWithPosts(int categoryId)
        {
            var category = _blogcontext.Categories
                .Include(c => c.Posts) 
                .FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                throw new Exception("Kategori bulunamadı");
            }

            return category;
        }


        public List<Post> GetPostsByCategoryId(int categoryId)
        {
            return _blogcontext.Posts
            .Where(p => p.CategoryId == categoryId)
            .ToList();
        }
    }
}