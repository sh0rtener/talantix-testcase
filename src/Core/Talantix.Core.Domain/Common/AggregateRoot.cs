using MediatR;

namespace Talantix.Core.Domain.Common;

public abstract class AggregateRoot<TId>
{
    private List<INotification> _domainEvents = new();
    public TId? Id { get; set; }
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents;

    public void AddDomainEvent(INotification notification) => _domainEvents.Add(notification);

    public void Clear() => _domainEvents.Clear();
}
