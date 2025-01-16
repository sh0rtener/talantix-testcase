using AutoMapper;
using MediatR;
using Talantix.Core.Application.Common;
using Talantix.Core.Domain.Todos;

namespace Talantix.Core.Application.Todos.Commands;

public class AddTodoCommand : IRequest
{
    public TodoDto Todo { get; set; }

    public AddTodoCommand(TodoDto todoDto) => Todo = todoDto;
}

public class AddTodoCommandHandler(
    ITodoRepository todoRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<AddTodoCommand>
{
    public async Task Handle(AddTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = mapper.Map<Todo>(request.Todo);
        await todoRepository.AddAsync(todo, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
    }
}
