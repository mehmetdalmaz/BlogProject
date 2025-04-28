using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Dto.CategoryDto
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? Description { get; set; } 
    }
}