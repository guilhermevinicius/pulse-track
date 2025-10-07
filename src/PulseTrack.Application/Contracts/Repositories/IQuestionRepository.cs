using PulseTrack.Domain.Aggregates.Question.Dto;
using PulseTrack.Domain.Aggregates.Question.Entities;

namespace PulseTrack.Application.Contracts.Repositories;

public interface IQuestionRepository
{
    Task InsertAsync(Question question, CancellationToken cancellationToken);
    
    Task<QuestionDto[]> ListQuestionsAsync(Guid surveyId, CancellationToken cancellationToken);
}