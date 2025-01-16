using Talantix.Core.Domain.Common;

namespace Talantix.Core.Domain.Todos;

public class Todo : AggregateRoot<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual TodoStatus Status { get; private set; } = TodoStatus.NotCompleted;

    public Todo(string title, string description)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        ArgumentException.ThrowIfNullOrEmpty(description);

        Title = title;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }

    public void SetAsComplete() => Status = TodoStatus.Completed;
}
