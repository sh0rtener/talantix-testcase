using AutoMapper;
using MediatR;
using Talantix.Core.Domain.Todos;

namespace Talantix.Core.Application.Todos.Queries;

public class GetTodoQuery : IRequest<TodoDto>
{
    public int Id { get; set; }

    public GetTodoQuery(int id) => Id = id;
}

public class GetTodoQueryHandler(ITodoRepository todoRepository, IMapper mapper)
    : IRequestHandler<GetTodoQuery, TodoDto>
{
    public async Task<TodoDto> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<TodoDto>(
            await todoRepository.FindAsync(x => x.Id == request.Id, cancellationToken)
        );
    }
}
