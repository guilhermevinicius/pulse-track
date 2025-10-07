using FluentValidation;

namespace PulseTrack.Application.UseCases.Questions.Commands.CreateQuestion;

public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    {
        RuleFor(x => x.SurveyId)
            .NotEmpty()
            .NotNull()
            .NotEqual(Guid.Empty);
        
        RuleFor(x => x.Text)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3);

        RuleFor(x => x.Type)
            .NotEmpty()
            .NotNull()
            .IsInEnum();

        RuleFor(x => x.Order)
            .NotEmpty()
            .NotNull();
    }
}