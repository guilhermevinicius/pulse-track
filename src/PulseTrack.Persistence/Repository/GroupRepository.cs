using Microsoft.EntityFrameworkCore;
using PulseTrack.Application.Contracts.Repositories;
using PulseTrack.Domain.Aggregates.Groups.Dtos;
using PulseTrack.Domain.Aggregates.Groups.Entities;
using PulseTrack.Persistence.Configurations;

namespace PulseTrack.Persistence.Repository;

internal sealed class GroupRepository(
    DataDbContext context)
    : IGroupRepository
{
    private readonly DbSet<Group> _groups = context.Set<Group>();

    public async Task<Group?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _groups.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<GroupDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _groups
            .AsNoTracking()
            .Select(group => new GroupDto(group.Id, group.Name))
            .ToArrayAsync(cancellationToken);
    }

    public async Task InsertAsync(Group group, CancellationToken cancellationToken)
    {
        await context.AddAsync(group, cancellationToken);
    }
}