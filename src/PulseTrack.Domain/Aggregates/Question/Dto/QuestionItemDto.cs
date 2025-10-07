namespace PulseTrack.Domain.Aggregates.Question.Dto;

public sealed record QuestionItemDto(
    Guid Id,
    Guid QuestionId,
    int Order,
    string Text);