using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Talantix.Core.Domain.Todos;

namespace Talantix.Infrastructure.EntityFramework;

public class AppDbContext : DbContext
{
    public virtual DbSet<Todo> Todos => Set<Todo>();

    public AppDbContext(DbContextOptions options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
