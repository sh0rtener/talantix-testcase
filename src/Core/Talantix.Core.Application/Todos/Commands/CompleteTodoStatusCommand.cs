using MediatR;
using Talantix.Core.Application.Common;
using Talantix.Core.Domain.Todos;

namespace Talantix.Core.Application.Todos.Commands;

public class CompleteTodoStatusCommand : IRequest
{
    public int Id { get; set; }

    public CompleteTodoStatusCommand(int id)
    {
        Id = id;
    }
}

public class CompleteTodoStatusCommandHandler(
    ITodoRepository todoRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<CompleteTodoStatusCommand>
{
    public async Task Handle(CompleteTodoStatusCommand request, CancellationToken cancellationToken)
    {
        var todo =
            await todoRepository.FindAsync(x => x.Id == request.Id)
            ?? throw new InvalidDataException("Todo wasn't found");

        todo.SetAsComplete();

        await todoRepository.UpdateAsync(todo, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
    }
}
