using PulseTrack.Domain.SeedWorks;

namespace PulseTrack.Domain.Aggregates.Groups.Entities;

public class Group : Entity
{
    public string Name { get; private set; }

    private Group(string name)
    {
        Name = name;
    }

    public static Group Create(string name)
    {
        return new Group(name);
    }
}