using FluentResults;
using MediatR;

namespace PulseTrack.Application.Contracts.Messaging;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;