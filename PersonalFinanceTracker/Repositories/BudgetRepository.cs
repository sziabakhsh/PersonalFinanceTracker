using PersonalFinanceTracker.Data;
using PersonalFinanceTracker.Interfaces;
using PersonalFinanceTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly AppDbContext _context;
        public BudgetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Budget>> GetAllAsync(Guid? userId) =>
            await _context.Budgets.Where(b => b.UserId == userId).ToListAsync();

        public async Task<Budget?> GetByIdAsync(Guid id, Guid? userId) =>
            await _context.Budgets.FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);
        

        public async Task<Budget?> AddAsync(Budget budget)
        {
            await _context.Budgets.AddAsync(budget);
            await _context.SaveChangesAsync();
            return budget;
        }

        public async Task<Budget?> UpdateAsync(Budget budget)
        {
            _context.Budgets.Update(budget);
            await _context.SaveChangesAsync();
            return budget;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var budget = await _context.Budgets.FirstOrDefaultAsync(b => b.Id == id);
            if (budget == null) return false;

            _context.Budgets.Remove(budget);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
