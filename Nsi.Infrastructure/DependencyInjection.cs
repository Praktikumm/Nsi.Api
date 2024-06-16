using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nsi.Application.Common.Interfaces;
using Nsi.Infrastructure.Configuration;
using Nsi.Infrastructure.Contexts;
using Nsi.Infrastructure.Services;

namespace Nsi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConfiguration = new PostgresDbConfiguration();
        configuration.GetSection("PostgresDbConfiguration").Bind(dbConfiguration);
        services.AddDbContext<NsiDbContext>(options => options.UseNpgsql(dbConfiguration.ConnectionString,
            x => x.MigrationsAssembly(typeof(NsiDbContext).Assembly.FullName)));
        services.AddScoped<INsiDbContext>(provider => provider.GetService<NsiDbContext>()!);
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}