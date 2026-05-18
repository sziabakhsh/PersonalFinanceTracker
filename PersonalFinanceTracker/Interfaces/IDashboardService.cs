using PersonalFinanceTracker.DTOs.Dashboard;

namespace PersonalFinanceTracker.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardSummaryDto> GetSummaryAsync(Guid userId);
    }
}
