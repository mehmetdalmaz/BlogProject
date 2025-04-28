using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogProject.Dto.CategoryDto;
using BlogProject.Dto.CommentDto;
using BlogProject.Dto.LikeDto;
using BlogProject.Dto.PostDto;
using BlogProject.Entity.Models;

namespace BlogProject.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          

            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<Like, CreateLikeDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();

        }
    }
}