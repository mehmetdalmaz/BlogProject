using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogProject.Dto.CategoryDto;
using BlogProject.Entity.Models;

namespace BlogProject.Api.Mapping
{
    public class CategoryMapping :Profile
    {
         public CategoryMapping()
         {
             CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, ResulCategoryDto>().ReverseMap();
         }

    }
}