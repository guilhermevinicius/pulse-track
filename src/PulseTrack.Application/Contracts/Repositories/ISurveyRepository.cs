using PulseTrack.Domain.Aggregates.Survey.Dto;
using PulseTrack.Domain.Aggregates.Survey.Entities;

namespace PulseTrack.Application.Contracts.Repositories;

public interface ISurveyRepository
{
    Task<Survey?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<SurveyDto[]> ListSurveysAsync(Guid groupId, CancellationToken cancellationToken);
    Task InsertAsync(Survey survey, CancellationToken cancellationToken);
}