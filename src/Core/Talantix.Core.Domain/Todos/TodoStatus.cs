using Talantix.Core.Domain.Common;

namespace Talantix.Core.Domain.Todos;

public class TodoStatus : ValueObject
{
    private string _status = null!;
    public string Status => _status;
    public static TodoStatus NotCompleted => new("not completed");
    public static TodoStatus Completed => new("completed");

    private TodoStatus(string status) => _status = status;

    protected TodoStatus() { }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Status;
    }
}
