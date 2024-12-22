using System.ComponentModel.DataAnnotations;

namespace BlogApp.API.DTOs.CategoryDTOs
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
