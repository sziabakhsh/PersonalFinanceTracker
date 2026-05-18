using PersonalFinanceTracker.DTOs.Account;
using PersonalFinanceTracker.Entities;
//using PersonalFinanceTracker.Services;

namespace PersonalFinanceTracker.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this RegisterRequestDto request)
        {
            return new User
            {
                Email = request.Email,
                Password =request.Password,
                FullName = request.FullName,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
