using System.Security.Claims;

namespace DevTracker.API.Helpers;

public static class ClaimsExtensions
{
    public const string NAME_IDENTIFIER_CLAIM = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

    public static long? GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var id = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == NAME_IDENTIFIER_CLAIM)?.Value;

        if (string.IsNullOrEmpty(id))
        {
            return null;
        }

        return long.Parse(id);
    }
}
