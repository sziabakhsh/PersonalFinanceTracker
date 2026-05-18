using PersonalFinanceTracker.Entities;
using PersonalFinanceTracker.DTOs.Transaction;

namespace PersonalFinanceTracker.Mappers
{
    public static class TransactionMapper
    {
        public static TransactionDto ToTransactionDto(this Transaction transaction)
        {
            return new TransactionDto
            {
                Id = transaction.Id,
                CategoryId = transaction.CategoryId,
                Amount = transaction.Amount,
                Type = transaction.Type,
                Title = transaction.Title,
                Description = transaction.Description,
                TransactionDate = transaction.TransactionDate,
                CreatedAt = transaction.CreatedAt,
                UpdatedAt = transaction.UpdatedAt
            };
        }

        public static Transaction ToTransaction(this TransactionRequestDto requestDto, Guid userId)
        {
            return new Transaction
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                CategoryId = requestDto.CategoryId,
                Amount = requestDto.Amount,
                Type = requestDto.Type,
                Title = requestDto.Title,
                Description = requestDto.Description,
                TransactionDate = requestDto.TransactionDate,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
