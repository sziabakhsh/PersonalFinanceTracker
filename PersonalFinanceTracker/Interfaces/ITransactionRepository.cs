using PersonalFinanceTracker.Entities;

namespace PersonalFinanceTracker.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllAsync(Guid? userId);
        Task<Transaction?> GetByIdAsync(Guid id, Guid? userId);
        Task<Transaction?> AddAsync(Transaction transaction);
        Task<Transaction?> UpdateAsync(Transaction transaction);
        Task<bool> DeleteAsync(Guid id);

        Task<decimal> GetTotalIncomeAsync(Guid userId);
        Task<decimal> GetTotalExpenseAsync(Guid userId);
        Task<List<Transaction>> GetRecentTransactionsAsync(Guid userId, int takeNo);
    }
}
