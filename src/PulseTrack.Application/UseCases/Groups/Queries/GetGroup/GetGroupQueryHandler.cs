using FluentResults;
using PulseTrack.Application.Contracts.Messaging;
using PulseTrack.Application.Contracts.Repositories;
using PulseTrack.Domain.Aggregates.Groups.Dtos;

namespace PulseTrack.Application.UseCases.Groups.Queries.GetGroup;

internal sealed class GetGroupQueryHandler(
    IGroupRepository groupRepository)
    : IQueryHandler<GetGroupQuery, GroupDto>
{
    public async Task<Result<GroupDto>> Handle(GetGroupQuery query, CancellationToken cancellationToken)
    {
        var group = await groupRepository.GetByIdAsync(query.Id, cancellationToken);
        if (group is null)
            return Result.Fail("Group not found");

        return new GroupDto(group.Id, group.Name);
    }
}