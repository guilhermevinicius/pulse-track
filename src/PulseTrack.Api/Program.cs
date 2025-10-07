using PulseTrack.Api.Configurations;
using PulseTrack.Application.Configurations;
using PulseTrack.Persistence.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureApi(builder.Configuration)
    .ConfigureApplication()
    .ConfigurePersistence(builder.Configuration);

var app = builder.Build();

await app
    .UseApi()
    .RunAsync();
