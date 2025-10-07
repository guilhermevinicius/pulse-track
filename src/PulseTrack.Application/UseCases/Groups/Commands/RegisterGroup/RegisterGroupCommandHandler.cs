using FluentResults;
using PulseTrack.Application.Contracts.Messaging;
using PulseTrack.Application.Contracts.Repositories;
using PulseTrack.Domain.Aggregates.Groups.Entities;
using PulseTrack.Domain.SeedWorks;

namespace PulseTrack.Application.UseCases.Groups.Commands.RegisterGroup;

internal sealed class RegisterGroupCommandHandler(
    IGroupRepository groupRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RegisterGroupCommand, bool>
{
    public async Task<Result<bool>> Handle(RegisterGroupCommand command, CancellationToken cancellationToken)
    {
        var group = Group.Create(command.Name);

        await groupRepository.InsertAsync(group, cancellationToken);

        return await unitOfWork.CommitAsync(cancellationToken);
    }
}