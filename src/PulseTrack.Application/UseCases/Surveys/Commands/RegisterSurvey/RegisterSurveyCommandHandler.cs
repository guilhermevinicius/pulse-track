using FluentResults;
using PulseTrack.Application.Contracts.Messaging;
using PulseTrack.Application.Contracts.Repositories;
using PulseTrack.Domain.Aggregates.Survey.Entities;
using PulseTrack.Domain.SeedWorks;

namespace PulseTrack.Application.UseCases.Surveys.Commands.RegisterSurvey;

internal sealed class RegisterSurveyCommandHandler(
    IGroupRepository groupRepository,
    ISurveyRepository surveyRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RegisterSurveyCommand, bool>
{
    public async Task<Result<bool>> Handle(RegisterSurveyCommand command, CancellationToken cancellationToken)
    {
        var group = await groupRepository.GetByIdAsync(command.GroupId, cancellationToken);
        if(group is null)
            return Result.Fail("Group not found");

        var survey = Survey.Create(
            command.GroupId,
            command.Title,
            command.Description);

        await surveyRepository.InsertAsync(survey, cancellationToken);

        return await unitOfWork.CommitAsync(cancellationToken);
    }
}