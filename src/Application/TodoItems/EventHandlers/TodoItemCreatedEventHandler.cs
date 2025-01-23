using Mohaymen.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Mohaymen.Application.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger) : INotificationHandler<TodoItemCreatedEvent>
{
    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Mohaymen Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
