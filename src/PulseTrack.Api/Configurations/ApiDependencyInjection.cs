using PulseTrack.Api.Configurations.Endpoints;
using PulseTrack.Api.Configurations.HealthCheck;
using PulseTrack.Api.Extensions;
using Scalar.AspNetCore;

namespace PulseTrack.Api.Configurations;

internal static class ApiDependencyInjection
{
    internal static WebApplication UseApi(this WebApplication app)
    {
        app.MapOpenApi();

        app.MapScalarApiReference();

        app.UseHealthCheckConfiguration();

        app.UseCors(x
            => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseExceptionHandler();

        app.ApplyMigrations();

        app.MapEndpoints();

        return app;
    }

    internal static IServiceCollection ConfigureApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpoints();

        services.AddOpenApi();

        services.AddHealthCheckConfiguration(configuration);

        services.AddCors();

        services.AddAuthentication();

        services.AddAuthorization();

        services.AddProblemDetails();

        return services;
    }
}