using System.Security.Claims;

namespace Ackbar.Api
{
    public interface IJwtUtils
    {
        string GenerateJwt(long id);
        long? GetUserIdFromContext(ClaimsPrincipal currentUser);
    }
}