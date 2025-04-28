using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Data.Abstract;
using BlogProject.Entity.Models;

namespace BlogProject.Business.Concrete
{
    public class CommentManager : ICommentService
    {
         private readonly ICommentDal _Commentdal;
        public CommentManager(ICommentDal CommentDal)
        {
            _Commentdal = CommentDal;
        }
        public void TDelete(Comment t)
        {
            _Commentdal.Delete(t);
        }

        public Comment TGetByID(int id)
        {
            return _Commentdal.GetByID(id);

        }

        public List<Comment> TGetList()
        {
            return _Commentdal.GetList();
        }

        public void TInsert(Comment t)
        {
            _Commentdal.Insert(t);
        }

        public void TUpdate(Comment t)
        {
            _Commentdal.Update(t);
        }
}
}