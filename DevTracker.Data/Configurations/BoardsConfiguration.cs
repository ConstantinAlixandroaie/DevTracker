using DevTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevTracker.Data.Configurations;

public class BoardsConfiguration : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> b)
    {
        b.HasKey(entity => entity.Id).HasName("PK_Board");

        b.Property(x => x.Title)
            .HasMaxLength(255)
            .IsRequired();

        b.HasOne(x => x.Owner)
       .WithMany(x => x.Boards)
       .HasForeignKey(x => x.OwnerId)
       .HasPrincipalKey(x => x.Id)
       .IsRequired();

        b.HasOne(x => x.Owner)
        .WithMany(x => x.Boards)
        .HasForeignKey(x => x.OwnerId)
        .HasPrincipalKey(x => x.Id)
        .IsRequired();

        b.HasOne(x => x.CreatedBy)
        .WithMany(x => x.CreatedBoards)
        .HasForeignKey(x => x.CreatedById)
        .IsRequired();
    }
}
