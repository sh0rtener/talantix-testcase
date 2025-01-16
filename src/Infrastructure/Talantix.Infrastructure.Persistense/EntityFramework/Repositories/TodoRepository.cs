using Talantix.Core.Domain.Todos;

namespace Talantix.Infrastructure.EntityFramework.Repositories;

public class TodoRepository : EfRepository<Todo>, ITodoRepository
{
    public TodoRepository(AppDbContext context)
        : base(context) { }
}
