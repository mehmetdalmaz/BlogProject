using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogProject.Data.Abstract;
using BlogProject.Dto.PostDto;
using BlogProject.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ResultPostDto>> GetAllPosts()
        {
            var posts = _postService.TGetList();
            var result = _mapper.Map<List<ResultPostDto>>(posts);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<ResultPostDto> GetPostById(int id)
        {
            var post = _postService.TGetByID(id);
            if (post == null)
                return NotFound($"Post bulunamadı. (id: {id})");

            var result = _mapper.Map<ResultPostDto>(post);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreatePost(CreatePostDto createPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdString = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
            {
                return Unauthorized("Geçerli bir kullanıcı bulunamadı.");
            }

            var post = _mapper.Map<Post>(createPostDto);
            post.UserId = userId; // Burada Claims'ten gelen userId'yi atıyoruz.

            _postService.TInsert(post);

            return Ok("Post başarıyla eklendi.");
        }




        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var post = _postService.TGetByID(id);
            if (post == null)
                return NotFound($"Post bulunamadı. (id: {id})");

            _postService.TDelete(post);
            return Ok("Post başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdatePost(UpdatePostDto updatePostDto)
        {
            var post = _mapper.Map<Post>(updatePostDto);
            _postService.TUpdate(post);
            return Ok("Post başarıyla güncellendi.");
        }


        [HttpGet("most-commented")]
        public ActionResult<List<ResultPostDto>> GetMostCommentedPosts()
        {
            var posts = _postService.GetMostCommentedPosts();
            if (posts == null || !posts.Any())
                return NotFound("Yorum yapılan post bulunamadı.");

            var result = _mapper.Map<List<ResultPostDto>>(posts);
            return Ok(result);
        }

        [HttpGet("popular")]
        public ActionResult<List<ResultPostDto>> GetPopularPosts()
        {
            var posts = _postService.GetPopularPosts();
            if (posts == null || !posts.Any())
                return NotFound("Popüler post bulunamadı.");

            var result = _mapper.Map<List<ResultPostDto>>(posts);
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<List<ResultPostDto>> GetPostsByUser(Guid userId)
        {
            var posts = _postService.GetPostsByUser(userId);
            if (posts == null || !posts.Any())
                return NotFound($"Kullanıcıya ait post bulunamadı. (Kullanıcı ID: {userId})");

            var result = _mapper.Map<List<ResultPostDto>>(posts);
            return Ok(result);
        }

        [HttpGet("category/{categoryId}")]
        public ActionResult<List<ResultPostDto>> GetPostsByCategory(int categoryId)
        {
            var posts = _postService.GetPostsByCategory(categoryId);
            if (posts == null || !posts.Any())
                return NotFound($"Kategoriye ait post bulunamadı. (Kategori ID: {categoryId})");

            var result = _mapper.Map<List<ResultPostDto>>(posts);
            return Ok(result);
        }

        [HttpGet("recent")]
        public ActionResult<List<ResultPostDto>> GetRecentPosts([FromQuery] DateTime afterDate)
        {
            var posts = _postService.GetRecentPosts(afterDate);
            if (posts == null || !posts.Any())
                return NotFound("Belirtilen tarihten sonra post bulunamadı.");

            var result = _mapper.Map<List<ResultPostDto>>(posts);
            return Ok(result);
        }
    }

}