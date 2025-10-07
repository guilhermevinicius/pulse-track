using System.Net;
using MediatR;
using PulseTrack.Api.Configurations.Endpoints;
using PulseTrack.Api.Endpoints.V1.Requests;
using PulseTrack.Api.Extensions;
using PulseTrack.Application.UseCases.Questions.Commands.CreateQuestion;
using PulseTrack.Application.UseCases.Questions.Queries.ListQuestion;

namespace PulseTrack.Api.Endpoints.V1;

internal sealed class QuestionEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/questions")
            .WithTags(Tags.Questions);

        group.MapGet("{surveyId:guid}", ListQuestions);
        group.MapPost("{surveyId:guid}", CreateQuestion);
    }

    #region Endpoints

    /// <summary>
    /// Returns a list of questions.
    /// </summary>
    /// <param name="surveyId"></param>
    /// <param name="sender"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private static async Task<IResult> ListQuestions(Guid surveyId, ISender sender, CancellationToken cancellationToken)
    {
        var query = new ListQuestionQuery(surveyId);
        
        var result = await sender.Send(query, cancellationToken);

        return result.CustomResponse(HttpStatusCode.OK);
    }
    
    private static async Task<IResult> CreateQuestion(Guid surveyId, ISender sender, CreateQuestionRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateQuestionCommand(surveyId,
            request.Text,
            request.Type,
            request.Order);

        var result = await sender.Send(command, cancellationToken);

        return result.CustomResponse(HttpStatusCode.Created);
    }

    #endregion
    
}