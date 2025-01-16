namespace Talantix.Core.Application.Common;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken = default);
    Task RollbackAsync(CancellationToken cancellationToken = default);
}
