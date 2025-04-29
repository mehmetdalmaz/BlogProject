using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogProject.Dto.LikeDto;
using BlogProject.Entity.Models;

namespace BlogProject.Api.Mapping
{
    public class LikeMapping : Profile
    {
        public LikeMapping()
        {
            CreateMap<Like, CreateLikeDto>().ReverseMap();
            CreateMap<Post, UpdateLikeDto>().ReverseMap();
            CreateMap<Post, ResultLikeDto>().ReverseMap();
        }
    }
}