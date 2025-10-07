using PulseTrack.Application.Contracts.Messaging;
using PulseTrack.Domain.Aggregates.Question.Enums;

namespace PulseTrack.Application.UseCases.Questions.Commands.CreateQuestion;

public sealed record CreateQuestionCommand(
    Guid SurveyId,
    string Text,
    QuestionType Type,
    int Order)
    : ICommand<bool>;