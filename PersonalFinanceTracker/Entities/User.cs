using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker.Entities
{
    [Index(nameof(Email), IsUnique = true, Name = "ix_users_email")]
    public class User
    {
        [Key] 
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)] 
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "timestamp with time zone")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "timestamp with time zone")]
        public DateTime? UpdatedAt { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public List<Budget> Budgets { get; set; } = new List<Budget>();
        public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
