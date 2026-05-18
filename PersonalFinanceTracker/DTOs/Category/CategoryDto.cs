using PersonalFinanceTracker.Entities;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker.DTOs.Category
{
    public class CategoryDto
    {
        [Key]
        public Guid Id { get; set; }
//        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
