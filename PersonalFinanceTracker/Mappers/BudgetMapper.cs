using PersonalFinanceTracker.DTOs.Budget;
using PersonalFinanceTracker.Entities;

namespace PersonalFinanceTracker.Mappers
{
    public static class BudgetMapper
    {
        public static BudgetDto ToBudgetDto(this Budget budget)
        {
            return new BudgetDto
            {
                Id = budget.Id,
                CategoryId = budget.CategoryId,
                Year = budget.Year,
                Month = budget.Month,
                MonthlyLimit = budget.MonthlyLimit
            };
        }

        public static Budget ToBudget (this BudgetRequestDto requestDto, Guid userId)
        {
            return new Budget
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                CategoryId = requestDto.CategoryId,
                Year = requestDto.Year,
                Month = requestDto.Month,
                MonthlyLimit = requestDto.MonthlyLimit
            };
        }
    }
}
