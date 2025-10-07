using PulseTrack.Domain.Aggregates.Groups.Dtos;
using PulseTrack.Domain.Aggregates.Groups.Entities;

namespace PulseTrack.Application.Contracts.Repositories;

public interface IGroupRepository
{
    Task<Group?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<GroupDto[]> GetAllAsync(CancellationToken cancellationToken);
    Task InsertAsync(Group group, CancellationToken cancellationToken);   
}