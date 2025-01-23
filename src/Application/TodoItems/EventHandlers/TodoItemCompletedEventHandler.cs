using Mohaymen.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Mohaymen.Application.TodoItems.EventHandlers;

public class TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger) : INotificationHandler<TodoItemCompletedEvent>
{
    public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Mohaymen Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
