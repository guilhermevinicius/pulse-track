using PulseTrack.Domain.SeedWorks;

namespace PulseTrack.Domain.Aggregates.Survey.Entities;

public class SurveySettings : Entity
{
    public Guid SurveyId { get; private set; }
    public Survey Survey { get; private set; }
    public bool AcceptAnswer { get; private set; }
    public bool UseDate { get; private set; }
    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public bool UseDuration { get; private set; }
    public int? Duration { get; private set; }
    public bool SendNotification { get; private set; }
    public bool CanEditAnswer { get; private set; }

    private SurveySettings(Guid surveyId, bool acceptAnswer)
    {
        SurveyId = surveyId;
        AcceptAnswer = acceptAnswer;
    }

    public static SurveySettings Create(Guid surveyId, bool acceptAnswer)
    {
        return new SurveySettings(surveyId, acceptAnswer);
    }
}