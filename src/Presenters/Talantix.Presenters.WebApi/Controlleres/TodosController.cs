using MediatR;
using Microsoft.AspNetCore.Mvc;
using Talantix.Core.Application.Todos;
using Talantix.Core.Application.Todos.Commands;
using Talantix.Core.Application.Todos.Queries;
using Talantix.Core.Domain.Todos;

namespace Talantix.Presenters.WebApi.Controllers;

[ApiController]
[Route("api/todos")]
public class TodosController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetTodoQuery(id), cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        CancellationToken cancellationToken,
        int take = int.MaxValue,
        int skip = 0
    )
    {
        var result = await mediator.Send(
            new GetTodosQuery() { Take = take, Skip = skip },
            cancellationToken
        );
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TodoDto todoDto, CancellationToken cancellationToken)
    {
        todoDto.Status = TodoStatus.NotCompleted.Status;
        await mediator.Send(new AddTodoCommand(todoDto), cancellationToken);
        return Accepted();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        TodoDto todoDto,
        CancellationToken cancellationToken
    )
    {
        await mediator.Send(new UpdateTodoCommand(id, todoDto), cancellationToken);
        return Accepted();
    }

    [HttpPatch("{id}/compelete")]
    public async Task<IActionResult> Complete(int id, CancellationToken cancellationToken)
    {
        await mediator.Send(new CompleteTodoStatusCommand(id), cancellationToken);
        return Accepted();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id, CancellationToken cancellationToken)
    {
        await mediator.Send(new RemoveTodoCommand(id), cancellationToken);
        return Accepted();
    }
}
