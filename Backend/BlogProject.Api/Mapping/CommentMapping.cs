using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogProject.Dto.CommentDto;
using BlogProject.Entity.Models;

namespace BlogProject.Api.Mapping
{
    public class CommentMapping : Profile
    {
        public CommentMapping()
        {
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            CreateMap<Comment, ResultCommentDto>().ReverseMap();
        }
    }
}