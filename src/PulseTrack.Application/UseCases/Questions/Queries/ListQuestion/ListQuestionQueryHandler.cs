using FluentResults;
using PulseTrack.Application.Contracts.Messaging;
using PulseTrack.Application.Contracts.Repositories;
using PulseTrack.Domain.Aggregates.Question.Dto;

namespace PulseTrack.Application.UseCases.Questions.Queries.ListQuestion;

internal sealed class ListQuestionQueryHandler(
    ISurveyRepository surveyRepository,
    IQuestionRepository questionRepository)
    : IQueryHandler<ListQuestionQuery, QuestionDto[]>
{
    public async Task<Result<QuestionDto[]>> Handle(ListQuestionQuery query, CancellationToken cancellationToken)
    {
        var survey = await surveyRepository.GetByIdAsync(query.SurveyId, cancellationToken);
        if (survey is null)
            return Result.Fail("Survey not found");

        return await questionRepository.ListQuestionsAsync(query.SurveyId, cancellationToken);
    }
}