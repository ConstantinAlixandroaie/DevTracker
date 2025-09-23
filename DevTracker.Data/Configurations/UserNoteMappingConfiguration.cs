using DevTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevTracker.Data.Configurations;

public class UserNoteMappingConfiguration : IEntityTypeConfiguration<UserNoteMapping>
{
    public void Configure(EntityTypeBuilder<UserNoteMapping> b)
    {
        b.HasKey(x => x.Id)
            .HasName("PK_UserNoteMapping");
        b.Property(x => x.UserId)
            .IsRequired();
        b.Property(x => x.NoteId)
           .IsRequired();
        b.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
        b.HasOne(x => x.Note)
            .WithMany()
            .HasForeignKey(x => x.NoteId);

    }
}
