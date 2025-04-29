
using BlogProject.Data.Abstract;
using BlogProject.Entity.Models;

namespace BlogProject.Business.Concrete
{
    public class PostManager : IPostService
    {
          private readonly IPostDal _Postdal;
        public PostManager(IPostDal PostDal)
        {
            _Postdal = PostDal;
        }

        public List<Post> GetMostCommentedPosts()
        {
            return _Postdal.GetMostCommentedPosts();
        }

        public List<Post> GetPopularPosts()
        {
            return _Postdal.GetPopularPosts();
        }

        public List<Post> GetPostsByCategory(int categoryId)
        {
            return _Postdal.GetPostsByCategory(categoryId);
        }

        public List<Post> GetPostsByUser(Guid userId)
        {
            return _Postdal.GetPostsByUser(userId);
        }

        public List<Post> GetRecentPosts(DateTime afterDate)
        {
            return _Postdal.GetRecentPosts(afterDate);
        }

        public List<Post> SearchPosts(string keyword)
        {
            return _Postdal.SearchPosts(keyword);
        }

        public void TDelete(Post t)
        {
            _Postdal.Delete(t);
        }

        public Post TGetByID(int id)
        {
            return _Postdal.GetByID(id);

        }

        public List<Post> TGetList()
        {
            return _Postdal.GetList();
        }

        public void TInsert(Post t)
        {
            _Postdal.Insert(t);
        }

        public void TUpdate(Post t)
        {
            _Postdal.Update(t);
        }
    }
}