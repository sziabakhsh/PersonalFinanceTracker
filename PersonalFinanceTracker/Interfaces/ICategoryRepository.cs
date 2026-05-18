using PersonalFinanceTracker.Entities;

namespace PersonalFinanceTracker.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync(Guid? userId);
        Task<Category?> GetByIdAsync(Guid id, Guid? userId);
        Task<Category?> AddAsync(Category category);
        Task<Category?> UpdateAsync(Category category);
        Task<bool> DeleteAsync(Guid id);
    }
}
