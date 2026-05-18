using PersonalFinanceTracker.DTOs.Transaction;

namespace PersonalFinanceTracker.DTOs.Dashboard
{
    public class DashboardSummaryDto
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Balance { get; set; }
        public decimal IncomeThisMonth { get; set; }
        public decimal ExpenseThisMonth { get; set; }
        public List<TransactionDto> RecentTransactions { get; set; } = [];
    }
}
