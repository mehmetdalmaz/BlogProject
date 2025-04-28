using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Dto.CategoryDto
{
    public class CreateCategoryDto
    {
        public string? Name { get; set; }         // Zorunlu olabilir
        public string? Description { get; set; } // Opsiyonel açıklama

    }
}