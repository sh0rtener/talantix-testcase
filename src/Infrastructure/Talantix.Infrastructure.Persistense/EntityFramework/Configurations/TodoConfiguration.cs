using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talantix.Core.Domain.Todos;

namespace Talantix.Infrastructure.EntityFramework.Configurations;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.OwnsOne(x => x.Status).Property(x => x.Status).HasColumnName("status");
    }
}
