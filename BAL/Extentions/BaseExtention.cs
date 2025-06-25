using Microsoft.AspNetCore.Http;

namespace FinanceTracking.Extentions;

public static class BaseExtention
{
    public static string? GetUserId(this IHttpContextAccessor contextAccessor)
    {
        try
        {
            if (contextAccessor.HttpContext != null)
            {
                return contextAccessor.HttpContext.User.Claims.Where(x => x.Type == "id").Select(c => c.Value)
                    .FirstOrDefault();
            }

            return string.Empty;
        }
        catch
        {
            return null;
        }
    }
}