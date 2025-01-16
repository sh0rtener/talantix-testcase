using AutoMapper;
using MediatR;
using Talantix.Core.Application.Common;
using Talantix.Core.Domain.Todos;

namespace Talantix.Core.Application.Todos.Commands;

public class UpdateTodoCommand : IRequest
{
    public int Id { get; set; }
    public TodoDto Todo { get; set; }

    public UpdateTodoCommand(int id, TodoDto todoDto)
    {
        Id = id;
        Todo = todoDto;
    }
}

public class UpdateTodoCommandHandler(
    ITodoRepository todoRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateTodoCommand>
{
    public async Task Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo =
            await todoRepository.FindAsync(x => x.Id == request.Id)
            ?? throw new InvalidDataException("Todo wasn't found");
        todo.Title = request.Todo.Title;
        todo.Description = request.Todo.Description;

        await todoRepository.UpdateAsync(todo, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
    }
}
