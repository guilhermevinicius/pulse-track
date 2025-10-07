using Microsoft.EntityFrameworkCore;
using PulseTrack.Application.Contracts.Repositories;
using PulseTrack.Domain.Aggregates.Survey.Dto;
using PulseTrack.Domain.Aggregates.Survey.Entities;
using PulseTrack.Persistence.Configurations;

namespace PulseTrack.Persistence.Repository;

internal sealed class SurveyRepository(
    DataDbContext context) 
    : ISurveyRepository
{
    private readonly DbSet<Survey> _surveys = context.Set<Survey>();

    public async Task<Survey?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _surveys.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<SurveyDto[]> ListSurveysAsync(Guid groupId, CancellationToken cancellationToken)
    {
        return await _surveys
            .AsNoTracking()
            .Where(x => x.GroupId == groupId)
            .Select(x => new SurveyDto(x.Id, x.Title, x.Description))
            .ToArrayAsync(cancellationToken);
    }

    public async Task InsertAsync(Survey survey, CancellationToken cancellationToken)
    {
        await _surveys.AddAsync(survey, cancellationToken);
    }
}