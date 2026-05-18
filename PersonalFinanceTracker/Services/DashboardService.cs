using PersonalFinanceTracker.DTOs.Dashboard;
using PersonalFinanceTracker.Interfaces;
using PersonalFinanceTracker.Mappers;

namespace PersonalFinanceTracker.Services
{
    public class DashboardService: IDashboardService
    {
        private readonly ITransactionRepository _transactionRepository;
        public DashboardService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<DashboardSummaryDto> GetSummaryAsync(Guid userId)
        {
            var totalIncome = await _transactionRepository.GetTotalIncomeAsync(userId);
            var totalExpense = await _transactionRepository.GetTotalExpenseAsync(userId);
            var recentTransactions = await _transactionRepository.GetRecentTransactionsAsync(userId, 5);

            return new DashboardSummaryDto
            {
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                RecentTransactions = recentTransactions.Select(t=>t.ToTransactionDto()).ToList()
            };
        }
    }
}
