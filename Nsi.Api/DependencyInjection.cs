using Nsi.Api.Auth.Constants;
using Nsi.Api.Auth.Options;

namespace Nsi.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)

    {
        services.AddAuthentication().AddScheme<HeaderBasicDbAuthSchemeOptions, HeaderBasicDbAuthHandler>(
            AuthConstants.HeaderDbAuthSchema, options => configuration.GetSection("Auth:Header").Bind(options));
        return services;
    }
}