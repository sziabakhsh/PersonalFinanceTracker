using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceTracker.Entities
{
    public class Budget
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User? User { get; set; } = null!;
        [Required] 
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; } = null!;
        [Required]
        public int Year { get; set; }
        [Required]
        public int Month { get; set; }
        [Required]
        [Column(TypeName = "numeric(12, 2)")]
        public decimal MonthlyLimit { get; set; }

    }
}
