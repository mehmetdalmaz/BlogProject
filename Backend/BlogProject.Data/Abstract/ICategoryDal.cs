using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Data.Context;
using BlogProject.Entity.Models;

namespace BlogProject.Data.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {        
        Category GetCategoryWithPosts(int categoryId);
        List<Post> GetPostsByCategoryId(int categoryId);
    }
}