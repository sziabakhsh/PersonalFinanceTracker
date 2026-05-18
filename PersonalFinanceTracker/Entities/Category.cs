using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User? User { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Name { get; set; }=string.Empty;
        [Required]
        [StringLength(20)]
        public string Type { get; set; }=string.Empty;
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public List<Budget> Budgets { get; set; } = new List<Budget>();
    }
}
