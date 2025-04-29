using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Entity.Models;

namespace BlogProject.Data.Abstract
{
    public interface IPostDal : IGenericDal<Post>
    {
        List<Post> GetPostsByCategory(int categoryId);
        List<Post> GetPostsByUser(Guid userId);
        List<Post> SearchPosts(string keyword);
        List<Post> GetPopularPosts();
        List<Post> GetRecentPosts(DateTime afterDate);
        List<Post> GetMostCommentedPosts();
    }
}