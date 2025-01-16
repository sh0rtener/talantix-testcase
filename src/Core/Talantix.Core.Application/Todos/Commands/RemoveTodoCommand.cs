using MediatR;
using Talantix.Core.Application.Common;
using Talantix.Core.Domain.Todos;

namespace Talantix.Core.Application.Todos.Commands;

public class RemoveTodoCommand : IRequest
{
    public int Id { get; set; }

    public RemoveTodoCommand(int id) => Id = id;
}

public class RemoveTodoCommandHandler(ITodoRepository todoRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveTodoCommand>
{
    public async Task Handle(RemoveTodoCommand request, CancellationToken cancellationToken)
    {
        var todo =
            await todoRepository.FindAsync(x => x.Id == request.Id)
            ?? throw new InvalidDataException("Todo wasn't found");

        await todoRepository.RemoveAsync(todo, cancellationToken);
        await unitOfWork.CommitAsync();
    }
}
