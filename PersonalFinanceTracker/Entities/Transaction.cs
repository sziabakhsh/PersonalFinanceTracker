using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker.Entities
{
    [Index(nameof(TransactionDate), IsUnique =true, Name = "ix_transactions_date")]
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User? User { get; set; } = null!;
        [Required]
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        
        [Required]
        [Column(TypeName = "numeric(12, 2)")]
        public decimal Amount { get; set; }
        [Required]
        [StringLength(20)]
        public string Type { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }=string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = null!;
        [Required]
        [Column(TypeName = "timestamp with time zone")]
        public DateTime TransactionDate { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now; 
        public DateTime? UpdatedAt { get; set; }

    }
}
