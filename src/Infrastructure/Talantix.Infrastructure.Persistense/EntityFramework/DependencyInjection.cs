using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Talantix.Core.Application.Common;
using Talantix.Core.Domain.Todos;
using Talantix.Infrastructure.EntityFramework;
using Talantix.Infrastructure.EntityFramework.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ITodoRepository, TodoRepository>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();

        return services;
    }

    public static IServiceCollection UseEfContext(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        switch (configuration["ConnectionString:ProviderName"])
        {
            default:
                services.AddDbContext<AppDbContext>(o =>
                {
                    o.UseSqlite(configuration["ConnectionString:Value"]);
                    o.UseLazyLoadingProxies();
                    o.UseSnakeCaseNamingConvention();
                });
                break;
        }
        return services;
    }

    public static void InitializeDbByEf(this IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
        }
    }
}
