
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