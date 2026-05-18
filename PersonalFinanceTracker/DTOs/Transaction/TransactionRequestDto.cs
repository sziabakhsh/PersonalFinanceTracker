using PersonalFinanceTracker.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceTracker.DTOs.Transaction
{
    public class TransactionRequestDto
    {
        //public Guid UserId { get; set; }
        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [Column(TypeName = "numeric(12, 2)")]
        public decimal Amount { get; set; }
        [Required]
        [StringLength(20)]
        public string Type { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = null!;
        [Required]
        [Column(TypeName = "timestamp with time zone")]
        public DateTime TransactionDate { get; set; }
    }
}
