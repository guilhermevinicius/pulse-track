using PulseTrack.Application.Contracts.Messaging;
using PulseTrack.Domain.Aggregates.Groups.Dtos;

namespace PulseTrack.Application.UseCases.Groups.Queries.GetGroup;

public sealed record GetGroupQuery(
    Guid Id)
    : IQuery<GroupDto>;