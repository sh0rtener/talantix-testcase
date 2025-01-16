using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Talantix.Core.Domain.Common;

namespace Talantix.Infrastructure.EntityFramework.Repositories;

public class EfRepository<T>(AppDbContext context) : IRepository<T>
    where T : class
{
    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public async Task<T?> FindAsync(
        Expression<Func<T, bool>> spec,
        CancellationToken cancellationToken = default
    )
    {
        return spec is not null
            ? await context.Set<T>().FirstOrDefaultAsync(spec, cancellationToken)
            : await context.Set<T>().Order().FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAsync(
        Expression<Func<T, bool>>? spec = null,
        int take = int.MaxValue,
        int skip = 0,
        CancellationToken cancellationToken = default
    )
    {
        return spec is not null
            ? await context
                .Set<T>()
                .Order()
                .Where(spec)
                .Take(take)
                .Skip(skip)
                .ToListAsync(cancellationToken)
            : await context.Set<T>().Order().Take(take).Skip(skip).ToListAsync(cancellationToken);
    }

    public Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => context.Set<T>().Remove(entity));
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => context.Set<T>().Update(entity));
    }
}
