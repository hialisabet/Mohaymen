using System.Security.Claims;

using Mohaymen.Application.Common.Interfaces;

namespace Mohaymen.Web.Services;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public string? Id => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}
