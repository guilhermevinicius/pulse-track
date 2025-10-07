using PulseTrack.Application.Contracts.Messaging;

namespace PulseTrack.Application.UseCases.Groups.Commands.RegisterGroup;

public sealed record RegisterGroupCommand(
    string Name)
    : ICommand<bool>;