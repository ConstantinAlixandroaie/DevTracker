using DevTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevTracker.Data.Configurations;

public class TagTaskItemMappingsConfiguration : IEntityTypeConfiguration<TagTaskItemMapping>
{
    public void Configure(EntityTypeBuilder<TagTaskItemMapping> b)
    {
        b.HasKey(x => x.Id)
                .HasName("PK_TagTaskItemMapping");

        b.Property(x => x.TaskItemId)
            .IsRequired();

        b.Property(x => x.TagId)
            .IsRequired();

        b.HasIndex(x => new { x.TaskItemId, x.TagId })
             .IsUnique()
             .HasDatabaseName("IX_TagTaskItemMapping_TaskItemId_TagId");

        b.HasOne(x => x.TaskItem)
            .WithMany()
            .HasForeignKey(x => x.TaskItemId);

        b.HasOne(x => x.Tag)
            .WithMany()
            .HasForeignKey(x => x.TagId);
    }
}
