using PersonalFinanceTracker.Entities;
using PersonalFinanceTracker.Data;
using PersonalFinanceTracker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync(Guid? userId)=>
            await _context.Categories.Where(c => c.UserId == userId).ToListAsync();

        public async Task<Category?> GetByIdAsync(Guid id, Guid? userId) =>
            await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

        public async Task<Category?> AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
