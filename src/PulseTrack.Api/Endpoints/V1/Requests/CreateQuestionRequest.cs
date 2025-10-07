using PulseTrack.Domain.Aggregates.Question.Enums;

namespace PulseTrack.Api.Endpoints.V1.Requests;

public sealed record CreateQuestionRequest(
    string Text,
    QuestionType Type,
    int Order);