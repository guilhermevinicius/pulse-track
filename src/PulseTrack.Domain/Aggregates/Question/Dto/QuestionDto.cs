using PulseTrack.Domain.Aggregates.Question.Enums;

namespace PulseTrack.Domain.Aggregates.Question.Dto;

public sealed record QuestionDto(
    Guid Id,
    string Text,
    QuestionType Type,
    int Order,
    QuestionItemDto[] Items);