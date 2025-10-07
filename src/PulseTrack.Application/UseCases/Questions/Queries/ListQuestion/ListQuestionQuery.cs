using PulseTrack.Application.Contracts.Messaging;
using PulseTrack.Domain.Aggregates.Question.Dto;

namespace PulseTrack.Application.UseCases.Questions.Queries.ListQuestion;

public sealed record ListQuestionQuery(
    Guid SurveyId)
    : IQuery<QuestionDto[]>;