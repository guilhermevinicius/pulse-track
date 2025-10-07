using FluentValidation;

namespace PulseTrack.Application.UseCases.Surveys.Commands.RegisterSurvey;

public class RegisterSurveyCommandValidator : AbstractValidator<RegisterSurveyCommand>
{
    public RegisterSurveyCommandValidator()
    {
        RuleFor(x => x.GroupId)
            .NotEmpty()
            .NotNull()
            .NotEqual(Guid.Empty);

        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3);

        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull();
    }
}