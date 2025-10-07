using PulseTrack.Domain.SeedWorks;

namespace PulseTrack.Domain.Aggregates.Survey.Entities;

public class Survey : Entity
{
    public Guid GroupId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool IsActive { get; private set; } = true;
    public SurveySettings Settings { get; private set; }

    private Survey(Guid groupId, string title, string description)
    {
        GroupId = groupId;
        Title = title;
        Description = description;
        Settings = SurveySettings.Create(Id, true);
    }

    public static Survey Create(Guid groupId, string title, string description)
    {
        return new Survey(groupId, title, description);
    }

    public void Update(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}