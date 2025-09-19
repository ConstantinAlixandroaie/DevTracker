using DevTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevTracker.Data.Configurations;

public class TaskItemsConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> b)
    {
        b.HasKey(x => x.Id)
                .HasName("PK_TaskItem");

        b.Property(x => x.Title)
            .HasMaxLength(255)
            .IsRequired();

        b.Property(x => x.Status)
            .IsRequired();

        b.HasOne(x => x.Assignee)
           .WithMany(x => x.AssignedTasks)
           .HasForeignKey(x => x.AssigneeId)
           .IsRequired();

        b.HasOne(x => x.CreatedBy)
           .WithMany(x => x.CreatedTasks)
           .HasForeignKey(x => x.CreatedById)
           .IsRequired();
    }
}
