using DevTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevTracker.Data.Configurations;

public class UserBoardMappingsConfiguration : IEntityTypeConfiguration<UserBoardMapping>
{
    public void Configure(EntityTypeBuilder<UserBoardMapping> b)
    {
        b.HasKey(x => x.Id)
                .HasName("PK_UserBoardMapping");

        b.Property(x => x.UserId)
            .IsRequired();

        b.Property(x => x.BoardId)
            .IsRequired();

        b.HasIndex(x => new { x.UserId, x.BoardId })
            .IsUnique()
            .HasDatabaseName("IX_UserBoardMapping_UserId_BoardId");

        b.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);

        b.HasOne(x => x.Board)
            .WithMany()
            .HasForeignKey(x => x.BoardId);
    }
}
