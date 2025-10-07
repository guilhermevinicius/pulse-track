using Microsoft.EntityFrameworkCore;
using PulseTrack.Application.Contracts.Repositories;
using PulseTrack.Domain.Aggregates.Question.Dto;
using PulseTrack.Domain.Aggregates.Question.Entities;
using PulseTrack.Persistence.Configurations;

namespace PulseTrack.Persistence.Repository;

internal sealed class QuestionRepository(
    DataDbContext context) 
    : IQuestionRepository
{
    private readonly DbSet<Question> _questions = context.Set<Question>();

    public async Task InsertAsync(Question question, CancellationToken cancellationToken)
    {
        await _questions.AddAsync(question, cancellationToken);
    }

    public async Task<QuestionDto[]> ListQuestionsAsync(Guid surveyId, CancellationToken cancellationToken)
    {
        return await _questions
            .AsNoTracking()
            .Where(x => x.SurveyId == surveyId)
            .OrderBy(x => x.Order)
            .Select(question => new QuestionDto(
                question.Id,
                question.Text,
                question.Type,
                question.Order,
                question.Items.Select(item => new QuestionItemDto(
                    item.Id,
                    item.QuestionId,
                    item.Order,
                    item.Text)).ToArray()))
            .ToArrayAsync(cancellationToken);
    }
}