using System.Security.Claims;

namespace PersonalFinanceTracker.Helpers
{
    public static class UserHandler
    {
        public static Guid GetUserId (this ClaimsPrincipal user)
        {
            var id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Guid.Parse(id!);
        }

    }
}
