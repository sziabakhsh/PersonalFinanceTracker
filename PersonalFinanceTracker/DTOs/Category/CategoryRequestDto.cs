using PersonalFinanceTracker.Entities;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker.DTOs.Category
{
    public class CategoryRequestDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string Type { get; set; } = string.Empty;
    }
}
