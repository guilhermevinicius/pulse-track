using FluentValidation;

namespace PulseTrack.Application.UseCases.Surveys.Queries.ListSurveys;

public class ListSurveysQueryValidator : AbstractValidator<ListSurveysQuery>
{
    public ListSurveysQueryValidator()
    {
        RuleFor(x => x.GroupId)
            .NotEmpty()
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}