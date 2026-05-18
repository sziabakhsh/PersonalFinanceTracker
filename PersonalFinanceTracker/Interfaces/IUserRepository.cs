using PersonalFinanceTracker.Entities;

namespace PersonalFinanceTracker.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>>GetAllAsync();
        Task<User?> GetByEmailAsync(string email);
        Task<User?> AddAsync(User user);
        Task<User?> UpdateAsync(User user);
        Task<bool> DeleteAsync(Guid id);
    }
}
