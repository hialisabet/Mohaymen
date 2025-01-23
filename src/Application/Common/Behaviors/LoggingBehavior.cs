using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Mohaymen.Application.Common.Interfaces;

namespace Mohaymen.Application.Common.Behaviors;

public class LoggingBehavior<TRequest>(ILogger<TRequest> logger, IUser user, IIdentityService identityService) : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = user.Id ?? string.Empty;
        string? userName = string.Empty;

        if (!string.IsNullOrEmpty(userId))
        {
            userName = await identityService.GetUserNameAsync(userId);
        }

        logger.LogInformation("Mohaymen Request: {Name} {@UserId} {@UserName} {@Request}", requestName, userId, userName, request);
    }
}
