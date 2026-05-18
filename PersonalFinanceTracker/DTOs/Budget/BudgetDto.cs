using PersonalFinanceTracker.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceTracker.DTOs.Budget
{
    public class BudgetDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        [Column(TypeName = "numeric(12, 2)")]
        public decimal MonthlyLimit { get; set; }
    }
}
