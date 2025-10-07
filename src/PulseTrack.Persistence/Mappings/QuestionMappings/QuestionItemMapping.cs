using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PulseTrack.Domain.Aggregates.Question.Entities;

namespace PulseTrack.Persistence.Mappings.QuestionMappings;

internal sealed class QuestionItemMapping
    : IEntityTypeConfiguration<QuestionItem>
{
    public void Configure(EntityTypeBuilder<QuestionItem> builder)
    {
        builder.ToTable("question_items");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.HasIndex(x => x.Id);

        builder.Property(x => x.Text)
            .IsRequired();
        
        builder.Property(x => x.Order)
            .IsRequired();

        builder.Property(x => x.CreatedOn)
            .IsRequired();

        builder.Property(x => x.UpdatedOn)
            .IsRequired();

        builder.HasOne(x => x.Question)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}