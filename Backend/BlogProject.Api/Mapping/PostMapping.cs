using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogProject.Dto.PostDto;
using BlogProject.Entity.Models;

namespace BlogProject.Api.Mapping
{
    public class PostMapping : Profile
    {
        public PostMapping()
        {
            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<Post, UpdatePostDto>().ReverseMap();
            CreateMap<Post, ResultPostDto>().ReverseMap();

        }
    }
}