using PulseTrack.Application.Contracts.Messaging;
using PulseTrack.Domain.Aggregates.Survey.Dto;

namespace PulseTrack.Application.UseCases.Surveys.Queries.ListSurveys;

public sealed record ListSurveysQuery(
    Guid GroupId) 
    : IQuery<SurveyDto[]>;