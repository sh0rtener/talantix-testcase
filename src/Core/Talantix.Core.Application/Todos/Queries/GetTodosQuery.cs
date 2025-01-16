using AutoMapper;
using MediatR;
using Talantix.Core.Domain.Todos;

namespace Talantix.Core.Application.Todos.Queries;

public class GetTodosQuery : IRequest<IEnumerable<TodoDto>>
{
    public int Take { get; set; } = int.MaxValue;
    public int Skip { get; set; } = 0;
}

public class GetTodosQueryHandler(ITodoRepository todoRepository, IMapper mapper)
    : IRequestHandler<GetTodosQuery, IEnumerable<TodoDto>>
{
    public async Task<IEnumerable<TodoDto>> Handle(
        GetTodosQuery request,
        CancellationToken cancellationToken
    )
    {
        return mapper.Map<IEnumerable<TodoDto>>(
            await todoRepository.GetAsync(
                take: request.Take,
                skip: request.Skip,
                cancellationToken: cancellationToken
            )
        );
    }
}
