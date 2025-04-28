using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Data.Abstract;
using BlogProject.Entity.Models;

namespace BlogProject.Business.Concrete
{
    public class CategoryManager : ICategoryServie
    {
        private readonly ICategoryDal _categorydal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categorydal = categoryDal;
        }

        public Category GetCategoryWithPosts(int categoryId)
        {
            return _categorydal.GetCategoryWithPosts(categoryId);
        }

        public List<Post> GetPostsByCategoryId(int categoryId)
        {
            return _categorydal.GetPostsByCategoryId(categoryId);
        }

        public void TDelete(Category t)
        {
            _categorydal.Delete(t);
        }

        public Category TGetByID(int id)
        {
            return _categorydal.GetByID(id);

        }

        public List<Category> TGetList()
        {
            return _categorydal.GetList();
        }

        public void TInsert(Category t)
        {
            _categorydal.Insert(t);
        }

        public void TUpdate(Category t)
        {
            _categorydal.Update(t);
        }
    }
}