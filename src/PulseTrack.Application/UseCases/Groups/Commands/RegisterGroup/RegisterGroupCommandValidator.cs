using FluentValidation;

namespace PulseTrack.Application.UseCases.Groups.Commands.RegisterGroup;

public class RegisterGroupCommandValidator : AbstractValidator<RegisterGroupCommand>
{
    public RegisterGroupCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();
    }
}