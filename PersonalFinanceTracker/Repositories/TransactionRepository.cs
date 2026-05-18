using PersonalFinanceTracker.Interfaces;
using PersonalFinanceTracker.Entities;
using PersonalFinanceTracker.Data;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Enums;


namespace PersonalFinanceTracker.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;
        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetAllAsync(Guid? userId)=>
            await _context.Transactions.Where(t => t.UserId == userId).ToListAsync();


        public async Task<Transaction?> GetByIdAsync(Guid id, Guid? userId)=>
            await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

        public async Task<Transaction?> AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction?> UpdateAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
            if (transaction == null) return false;

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> GetTotalIncomeAsync(Guid userId) =>
            await _context.Transactions.Where(t => 
                t.UserId == userId 
                && t.Type == TransactionType.Income.ToString()).SumAsync(t => t.Amount);

        public async Task<decimal> GetTotalExpenseAsync(Guid userId) =>
            await _context.Transactions.Where(t =>
                t.UserId == userId
                && t.Type == TransactionType.Expense.ToString()).SumAsync(t => t.Amount);

        public async Task<List<Transaction>> GetRecentTransactionsAsync(Guid userId, int takeNo) =>
            await _context.Transactions.Where(t => t.UserId == userId)
                .OrderByDescending(t => t.TransactionDate)
                .Take(takeNo)
                .ToListAsync();
        
    }
}
