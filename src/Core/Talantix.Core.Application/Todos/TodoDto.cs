using Talantix.Core.Domain.Todos;

namespace Talantix.Core.Application.Todos;

public class TodoDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string Status { get; set; } = TodoStatus.NotCompleted.Status;
}
