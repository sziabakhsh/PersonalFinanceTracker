using PersonalFinanceTracker.Entities;

namespace PersonalFinanceTracker.Interfaces
{
    public interface IBudgetRepository
    {
        Task<List<Budget>> GetAllAsync(Guid? userId);
        Task<Budget?> GetByIdAsync(Guid id, Guid? userId);
        Task<Budget?> AddAsync(Budget budget);
        Task<Budget?> UpdateAsync(Budget budget);
        Task<bool> DeleteAsync(Guid id);
    }
}
