using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PulseTrack.Application.Contracts.Repositories;
using PulseTrack.Domain.SeedWorks;
using PulseTrack.Persistence.Repository;

namespace PulseTrack.Persistence.Configurations;

public static class PersistenceDependencyInjection
{
    public static IServiceCollection ConfigurePersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DataDbContext>(builder =>
            builder.UseNpgsql(configuration.GetConnectionString("Postgres"))
                .UseSnakeCaseNamingConvention());

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<DataDbContext>());

        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();

        return services;
    }
}