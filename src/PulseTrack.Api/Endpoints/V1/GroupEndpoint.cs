using System.Net;
using MediatR;
using PulseTrack.Api.Configurations.Endpoints;
using PulseTrack.Api.Extensions;
using PulseTrack.Application.UseCases.Groups.Commands.RegisterGroup;
using PulseTrack.Application.UseCases.Groups.Queries.GetGroup;
using PulseTrack.Application.UseCases.Groups.Queries.ListGroup;

namespace PulseTrack.Api.Endpoints.V1;

internal sealed class GroupEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/groups")
            .WithTags(Tags.Groups);

        group.MapGet("{id:guid}", GetById);
        group.MapGet("/", ListGroups);
        group.MapPost("/", RegisterGroup);
    }

    #region Endpoints

    /// <summary>
    /// Return a group by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="sender"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private static async Task<IResult> GetById(Guid id, ISender sender, CancellationToken cancellationToken)
    {
        var query = new GetGroupQuery(id);

        var result = await sender.Send(query, cancellationToken);

        return result.CustomResponse(HttpStatusCode.OK);
    }
    
    /// <summary>
    /// Returns a list of groups.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private static async Task<IResult> ListGroups(ISender sender, CancellationToken cancellationToken)
    {
        var quey = new ListGroupQuery();

        var result = await sender.Send(quey, cancellationToken);

        return result.CustomResponse(HttpStatusCode.OK);
    }
    
    /// <summary>
    /// Register a new group.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private static async Task<IResult> RegisterGroup(ISender sender, RegisterGroupCommand command,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.CustomResponse(HttpStatusCode.Created);
    }

    #endregion
    
}