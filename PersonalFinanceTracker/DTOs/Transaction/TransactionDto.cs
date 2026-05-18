using PersonalFinanceTracker.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceTracker.DTOs.Transaction
{
    public class TransactionDto
    {
        [Key]
        public Guid Id { get; set; }
        //public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        [Column(TypeName = "numeric(12, 2)")]
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = null!;
        [Column(TypeName = "timestamp with time zone")]
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
