using PersonalFinanceTracker.DTOs.Account;
using PersonalFinanceTracker.Entities;

namespace PersonalFinanceTracker.Interfaces
{
    public interface IAuthService
    {
        Task<UserTokenDto> LoginAsync(LoginDto dto);
        Task<UserTokenDto> RegisterAsync(RegisterRequestDto requestDto);
        Task<AuthResponseDto> RefreshTokenAsync(string refreshToken);
        Task LogoutAsync(string refreshToken);
    }
}
