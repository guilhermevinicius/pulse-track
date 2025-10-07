using FluentValidation;

namespace PulseTrack.Application.UseCases.Groups.Queries.GetGroup;

public class GetGroupQueryValidator : AbstractValidator<GetGroupQuery>
{
    public GetGroupQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}