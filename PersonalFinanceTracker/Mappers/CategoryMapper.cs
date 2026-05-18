using PersonalFinanceTracker.Entities;
using PersonalFinanceTracker.DTOs.Category;

namespace PersonalFinanceTracker.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Type = category.Type
            };
        }

        public static Category ToCategory(this CategoryRequestDto categoryRequestDto, Guid userId)
        {
            return new Category
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Name = categoryRequestDto.Name,
                Type = categoryRequestDto.Type
            };
        }
    }
}
