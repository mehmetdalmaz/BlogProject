using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogProject.Data.Abstract;
using BlogProject.Dto.CategoryDto;
using BlogProject.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServie _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryServie categoryServie, IMapper mapper)
        {
            _categoryService = categoryServie;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ResulCategoryDto>> GetAllCategories()
        {
            var categories = _categoryService.TGetList();
            var result = _mapper.Map<List<ResulCategoryDto>>(categories);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<ResulCategoryDto> GetCategoryById(int id)
        {
            var category = _categoryService.TGetByID(id);
            if (category == null)
                return NotFound($"Kategori bulunamadı. (id: {id})");

            var result = _mapper.Map<ResulCategoryDto>(category);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TInsert(value);
            return Ok("Kategori Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            _categoryService.TDelete(value);
            return Ok("Kategori Silindi");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(value);
            return Ok("Kategori Güncellendi");
        }
        [HttpGet("{id}/posts")]
        public IActionResult GetPostsByCategoryId(int id)
        {
            var posts = _categoryService.GetPostsByCategoryId(id);
            if (posts == null || posts.Count == 0)
                return NotFound($"Bu kategoriye ait post bulunamadı. (Kategori ID: {id})");

            return Ok(posts);
        }

        [HttpGet("{id}/withposts")]
        public IActionResult GetCategoryWithPosts(int id)
        {
            var category = _categoryService.GetCategoryWithPosts(id);
            if (category == null)
                return NotFound("Kategori bulunamadı.");

            return Ok(category);
        }

    }
}