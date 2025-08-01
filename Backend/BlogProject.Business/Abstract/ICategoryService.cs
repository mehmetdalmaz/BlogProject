using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Entity.Models;

namespace BlogProject.Data.Abstract
{
    public interface ICategoryServie: IGenericService<Category>
    {
        Category GetCategoryWithPosts(int categoryId); 
        List<Post> GetPostsByCategoryId(int categoryId);
    }
}