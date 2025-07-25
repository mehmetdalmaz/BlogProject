using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Data.Abstract;
using BlogProject.Data.Context;
using BlogProject.Data.Repository;
using BlogProject.Entity.Models;

namespace BlogProject.Data.EnitityFramework
{
    public class EfLikeDal : GenericRepository<Like>, ILikeDal
    {
        public EfLikeDal(BlogContext context) : base(context)
        {
        }
    }
}