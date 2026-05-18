using PersonalFinanceTracker.Entities;

namespace PersonalFinanceTracker.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User appUser);
    }
}
