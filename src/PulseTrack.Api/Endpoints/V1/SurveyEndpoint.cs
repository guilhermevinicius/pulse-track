using System.Net;
using MediatR;
using PulseTrack.Api.Configurations.Endpoints;
using PulseTrack.Api.Extensions;
using PulseTrack.Application.UseCases.Surveys.Commands.RegisterSurvey;
using PulseTrack.Application.UseCases.Surveys.Queries.ListSurveys;

namespace PulseTrack.Api.Endpoints.V1;

public class SurveyEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/surveys")
            .WithTags(Tags.Surveys);

        group.MapGet("{groupId:guid}", ListSurveys);
        group.MapPost("", RegisterSurvey);
    }

    #region Endpoints

    /// <summary>
    /// Returns a list of surveys.
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="sender"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private static async Task<IResult> ListSurveys(Guid groupId, ISender sender, CancellationToken cancellationToken)
    {
        var query = new ListSurveysQuery(groupId);

        var result = await sender.Send(query, cancellationToken);

        return result.CustomResponse(HttpStatusCode.OK);
    }
    
    /// <summary>
    /// Register a new survey.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private static async Task<IResult> RegisterSurvey(ISender sender, RegisterSurveyCommand command,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.CustomResponse(HttpStatusCode.Created);
    }

    #endregion
    
}