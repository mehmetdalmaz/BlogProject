using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogProject.Dto.CategoryDto;
using BlogProject.Dto.CommentDto;
using BlogProject.Dto.LikeDto;
using BlogProject.Dto.LoginDto;
using BlogProject.Dto.PostDto;
using BlogProject.Dto.RegisterDto;
using BlogProject.Dto.TokenResponseDto;
using BlogProject.Entity.Models;

namespace BlogProject.Api.Mapping
{
    public class AppUserMapping : Profile
    {
        public AppUserMapping()
        {

            CreateMap<AppUser, RegsiterDto>().ReverseMap();
            CreateMap<AppUser, LoginDto>().ReverseMap();
            CreateMap<AppUser, TokenResponseDto>().ReverseMap();

        }
    }
}