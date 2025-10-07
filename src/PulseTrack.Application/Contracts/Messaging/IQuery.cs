using FluentResults;
using MediatR;

namespace PulseTrack.Application.Contracts.Messaging;

public interface IQuery<TRequest> : IRequest<Result<TRequest>>;