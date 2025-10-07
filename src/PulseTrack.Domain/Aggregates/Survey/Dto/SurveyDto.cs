namespace PulseTrack.Domain.Aggregates.Survey.Dto;

public sealed record SurveyDto(
    Guid Id,
    string Title,
    string Description);