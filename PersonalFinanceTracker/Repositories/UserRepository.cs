using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Data;
using PersonalFinanceTracker.Entities;
using PersonalFinanceTracker.Interfaces;

namespace PersonalFinanceTracker.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
            => await _context.Users.ToListAsync();
      
        public async Task<User?> GetByEmailAsync(string email)
            => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        
        public async Task<User?> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user != null) return false;

             _context.Users.Remove(new User { Id = id });
             await _context.SaveChangesAsync();
             return true;
        }      
        
    }
}
