namespace PulseTrack.Api.Dto;

public sealed record CustomResponse(
    bool Success,
    int StatusCode,
    object? Data,
    List<string>? Messages,
    DateTimeOffset DateTimeOffset);