using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PulseTrack.Domain.Aggregates.Groups.Entities;

namespace PulseTrack.Persistence.Mappings.GroupMappings;

internal sealed class GroupMapping 
    : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("groups");

        builder.HasKey(group => group.Id);

        builder.HasIndex(group => group.Id);

        builder.Property(group => group.Id)
            .ValueGeneratedOnAdd();

        builder.Property(group => group.Name);

        builder.Property(x => x.CreatedOn)
            .IsRequired();

        builder.Property(x => x.UpdatedOn)
            .IsRequired();
    }
}