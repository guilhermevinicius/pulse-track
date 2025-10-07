using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PulseTrack.Domain.Aggregates.Survey.Entities;

namespace PulseTrack.Persistence.Mappings.SurveysMappings;

internal sealed class SurveySettingsMapping
    : IEntityTypeConfiguration<SurveySettings>
{
    public void Configure(EntityTypeBuilder<SurveySettings> builder)
    {
        builder.ToTable("survey_settings");

        builder.HasKey(survey => survey.Id);

        builder.Property(survey => survey.Id)
            .ValueGeneratedOnAdd();

        builder.HasIndex(x => x.Id);

        builder.Property(x => x.SurveyId)
            .IsRequired();
        
        builder.Property(x => x.AcceptAnswer)
            .IsRequired();

        builder.Property(x => x.UseDate)
            .IsRequired();

        builder.Property(x => x.StartDate);

        builder.Property(x => x.EndDate);

        builder.Property(x => x.UseDuration)
            .IsRequired();

        builder.Property(x => x.Duration);

        builder.Property(x => x.SendNotification)
            .IsRequired();

        builder.Property(x => x.CanEditAnswer)
            .IsRequired();

        builder.Property(x => x.CreatedOn)
            .IsRequired();

        builder.Property(x => x.UpdatedOn)
            .IsRequired();

        builder.HasOne(x => x.Survey)
            .WithOne()
            .HasForeignKey<Survey>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}