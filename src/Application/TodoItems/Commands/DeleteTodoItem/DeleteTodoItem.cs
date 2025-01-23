﻿using Mohaymen.Application.Common.Interfaces;
using Mohaymen.Domain.Events;

namespace Mohaymen.Application.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(int Id) : IRequest;

public class DeleteTodoItemCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteTodoItemCommand>
{
    public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        context.TodoItems.Remove(entity);

        entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

        await context.SaveChangesAsync(cancellationToken);
    }

}
