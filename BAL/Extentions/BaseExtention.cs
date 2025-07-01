using Microsoft.AspNetCore.Http;

namespace FinanceTracking.Extentions;

public static class BaseExtention
{
    public static Guid? GetUserId(this IHttpContextAccessor contextAccessor)
    {
        try
        {
            if (contextAccessor.HttpContext != null)
            {
                return Guid.Parse(contextAccessor.HttpContext.User.Claims.Where(x => x.Type == "id").Select(c => c.Value)
                    .FirstOrDefault());
            }

            return Guid.Empty;
        }
        catch
        {
            return null;
        }
    }
}