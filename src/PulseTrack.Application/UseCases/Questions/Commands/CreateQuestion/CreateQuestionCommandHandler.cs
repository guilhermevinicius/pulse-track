using FluentResults;
using PulseTrack.Application.Contracts.Messaging;
using PulseTrack.Application.Contracts.Repositories;
using PulseTrack.Domain.Aggregates.Question.Entities;
using PulseTrack.Domain.SeedWorks;

namespace PulseTrack.Application.UseCases.Questions.Commands.CreateQuestion;

internal sealed class CreateQuestionCommandHandler(
    ISurveyRepository surveyRepository,
    IQuestionRepository questionRepository,
    IUnitOfWork unitOfWork) 
    : ICommandHandler<CreateQuestionCommand, bool>
{
    public async Task<Result<bool>> Handle(CreateQuestionCommand command, CancellationToken cancellationToken)
    {
        var survey = await surveyRepository.GetByIdAsync(command.SurveyId, cancellationToken);
        if (survey is null)
            return Result.Fail("Survey not found");

        var question = Question.Create(
            command.SurveyId,
            command.Text,
            command.Type,
            command.Order);

        await questionRepository.InsertAsync(question, cancellationToken);

        return await unitOfWork.CommitAsync(cancellationToken);
    }
}