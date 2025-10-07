using FluentResults;
using PulseTrack.Application.Contracts.Messaging;
using PulseTrack.Application.Contracts.Repositories;
using PulseTrack.Domain.Aggregates.Survey.Dto;

namespace PulseTrack.Application.UseCases.Surveys.Queries.ListSurveys;

internal sealed class ListSurveysQueryHandler(
    ISurveyRepository surveyRepository)
    : IQueryHandler<ListSurveysQuery, SurveyDto[]>
{
    public async Task<Result<SurveyDto[]>> Handle(ListSurveysQuery query, CancellationToken cancellationToken)
    {
        return await surveyRepository.ListSurveysAsync(query.GroupId, cancellationToken);
    }
}