namespace PulseTrack.Domain.SeedWorks;

public interface IUnitOfWork
{
    Task<bool> CommitAsync(CancellationToken cancellationToken);
}