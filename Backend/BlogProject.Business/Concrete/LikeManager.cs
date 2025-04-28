using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Data.Abstract;
using BlogProject.Entity.Models;

namespace BlogProject.Business.Concrete
{
    public class LikeManager : ILikeService
    {
         private readonly ILikeDal _Likedal;
        public LikeManager(ILikeDal LikeDal)
        {
            _Likedal = LikeDal;
        }
        public void TDelete(Like t)
        {
            _Likedal.Delete(t);
        }

        public Like TGetByID(int id)
        {
            return _Likedal.GetByID(id);

        }

        public List<Like> TGetList()
        {
            return _Likedal.GetList();
        }

        public void TInsert(Like t)
        {
            _Likedal.Insert(t);
        }

        public void TUpdate(Like t)
        {
            _Likedal.Update(t);
        }
}
}