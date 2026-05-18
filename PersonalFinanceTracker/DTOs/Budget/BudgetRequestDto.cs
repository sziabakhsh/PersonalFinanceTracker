using PersonalFinanceTracker.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceTracker.DTOs.Budget
{
    public class BudgetRequestDto
    {
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Month { get; set; }
        [Required]
        [Column(TypeName = "numeric(12, 2)")]
        public decimal MonthlyLimit { get; set; }
    }
}
