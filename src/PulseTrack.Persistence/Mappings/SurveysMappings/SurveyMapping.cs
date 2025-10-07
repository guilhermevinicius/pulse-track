using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PulseTrack.Domain.Aggregates.Survey.Entities;

namespace PulseTrack.Persistence.Mappings.SurveysMappings;

internal sealed class SurveyMapping : IEntityTypeConfiguration<Survey>
{
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.ToTable("surveys");
        
        builder.HasKey(survey => survey.Id);
        
        builder.Property(survey => survey.Id)
            .ValueGeneratedOnAdd();

        builder.HasIndex(x => x.Id);

        builder.Property(x => x.GroupId)
            .IsRequired();

        builder.Property(x => x.Title)
            .IsRequired();

        builder.Property(x => x.Description)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.CreatedOn)
            .IsRequired();

        builder.Property(x => x.UpdatedOn)
            .IsRequired();

        builder.HasOne(x => x.Settings)
            .WithOne(x => x.Survey)
            .HasForeignKey<SurveySettings>(x => x.SurveyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}