using DevTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevTracker.Data.Configurations;

public class NotesConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> b)
    {
        b.HasKey(x => x.Id)
                .HasName("PK_Note");
        b.Property(x => x.Content)
            .IsRequired();

        b.Property(x => x.TaskItemId)
            .IsRequired();

        b.HasOne(x => x.TaskItem)
            .WithMany(x => x.Notes)
            .HasForeignKey(x => x.TaskItemId)
            .IsRequired();

        b.HasOne(x => x.CreatedBy)
            .WithMany(x => x.CreatedNotes)
            .HasForeignKey(x => x.CreatedById)
            .IsRequired();
    }
}
