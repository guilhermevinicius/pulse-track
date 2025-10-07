using FluentResults;
using PulseTrack.Application.Contracts.Messaging;
using PulseTrack.Application.Contracts.Repositories;
using PulseTrack.Domain.Aggregates.Groups.Dtos;

namespace PulseTrack.Application.UseCases.Groups.Queries.ListGroup;

internal sealed class ListGroupQueryHandler(
    IGroupRepository groupRepository)
    : IQueryHandler<ListGroupQuery, GroupDto[]>
{
    public async Task<Result<GroupDto[]>> Handle(ListGroupQuery query, CancellationToken cancellationToken)
        => await groupRepository.GetAllAsync(cancellationToken);
}