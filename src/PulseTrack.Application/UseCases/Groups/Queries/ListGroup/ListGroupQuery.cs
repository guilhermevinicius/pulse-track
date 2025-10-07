using PulseTrack.Application.Contracts.Messaging;
using PulseTrack.Domain.Aggregates.Groups.Dtos;

namespace PulseTrack.Application.UseCases.Groups.Queries.ListGroup;

public sealed record ListGroupQuery
    : IQuery<GroupDto[]>;