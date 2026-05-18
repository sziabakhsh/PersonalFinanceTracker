using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Entities;

namespace PersonalFinanceTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users =>Set<User>();
        public DbSet<Budget> Budgets =>Set<Budget>();
        public DbSet<Category> Categories=>Set<Category>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("users");
            builder.Entity<Budget>().ToTable("budgets");
            builder.Entity<Category>().ToTable("categories");
            builder.Entity<Transaction>().ToTable("transactions");
            builder.Entity<RefreshToken>().ToTable("refresh_tokens");
        }
    }
}
