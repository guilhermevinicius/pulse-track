using Microsoft.EntityFrameworkCore;
using PulseTrack.Domain.SeedWorks;

namespace PulseTrack.Persistence.Configurations;

public class DataDbContext(
    DbContextOptions<DataDbContext> options) 
    : DbContext(options), IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly);
    }

    public async Task<bool> CommitAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken) > 0;
    }
}