using PulseTrack.Application.Contracts.Messaging;

namespace PulseTrack.Application.UseCases.Surveys.Commands.RegisterSurvey;

public sealed record RegisterSurveyCommand(
    Guid GroupId,
    string Title,
    string Description)
    : ICommand<bool>;