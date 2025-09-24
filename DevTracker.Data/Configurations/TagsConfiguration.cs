using DevTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevTracker.Data.Configurations;

public class TagsConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> b)
    {
        b.HasKey(x => x.Id)
               .HasName("PK_Tag");
        b.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
        b.Property(x => x.Colour)
            .HasMaxLength(9);
        b.HasIndex(i => new { i.Name, i.Colour })
            .IsUnique();
    }
}
