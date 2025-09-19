using DevTracker.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevTracker.Data;

public class DevTrackerContext : IdentityDbContext<User, IdentityRole<long>, long>
{
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Board> Boards { get; set; }

    public DevTrackerContext(DbContextOptions<DevTrackerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);
        b.Entity<Board>(entity =>
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_Board");

            entity.Property(x => x.Title)
                .HasMaxLength(255)
                .IsRequired();

            entity.HasOne(x => x.Owner)
           .WithMany(x => x.Boards)
           .HasForeignKey(x => x.OwnerId)
           .HasPrincipalKey(x => x.Id)
           .IsRequired();

            entity.HasOne(x => x.Owner)
            .WithMany(x => x.Boards)
            .HasForeignKey(x => x.OwnerId)
            .HasPrincipalKey(x => x.Id)
            .IsRequired();

            entity.HasOne(x => x.CreatedBy)
            .WithMany(x => x.CreatedBoards)
            .HasForeignKey(x => x.CreatedById)
            .IsRequired();
        });

        b.Entity<TaskItem>(entity =>
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_TaskItem");

            entity.Property(x => x.Title)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(x => x.Status)
                .IsRequired();

            entity.HasOne(x => x.Assignee)
               .WithMany(x => x.AssignedTasks)
               .HasForeignKey(x => x.AssigneeId)
               .IsRequired();

            entity.HasOne(x => x.CreatedBy)
               .WithMany(x => x.CreatedTasks)
               .HasForeignKey(x => x.CreatedById)
               .IsRequired();

            entity.HasMany(x => x.Tags)
                .WithMany()
                .UsingEntity<TagTaskItemMapping>(
                    l => l.HasOne(x => x.Tag)
                        .WithMany()
                        .HasForeignKey(x => x.TagId),
                    r => r.HasOne(x => x.TaskItem)
                        .WithMany()
                        .HasForeignKey(x => x.TaskItemId),
                    j =>
                    {
                        j.HasKey(x => x.Id);
                        j.ToTable("TagTaskItemMappings");
                    }
                );
        });

        b.Entity<Note>(entity =>
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_Note");
            entity.Property(x => x.Content)
                .IsRequired();

            entity.Property(x => x.TaskItemId)
                .IsRequired();

            entity.HasOne(x => x.TaskItem)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.TaskItemId)
                .IsRequired();

            entity.HasOne(x => x.CreatedBy)
                .WithMany(x => x.CreatedNotes)
                .HasForeignKey(x => x.CreatedById)
                .IsRequired();
        });

        b.Entity<Tag>(entity =>
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_Tag");
            entity.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            entity.Property(x => x.Colour)
                .HasMaxLength(9);
        });

        b.Entity<TagTaskItemMapping>(entity =>
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_TagTaskItemMapping");

            entity.Property(x => x.TaskItemId)
                .IsRequired();

            entity.Property(x => x.TagId)
                .IsRequired();

            entity.HasIndex(x => new { x.TaskItemId, x.TagId })
                 .IsUnique()
                 .HasDatabaseName("IX_TagTaskItemMapping_TaskItemId_TagId");

            entity.HasOne(x => x.TaskItem)
                .WithMany()
                .HasForeignKey(x => x.TaskItemId);

            entity.HasOne(x => x.Tag)
                .WithMany()
                .HasForeignKey(x => x.TagId);
        });

        b.Entity<User>(entity =>
        {
            entity.HasMany(x => x.Boards)
            .WithMany(x => x.Users)
            .UsingEntity<UserBoardMapping>(
                l => l.HasOne(x => x.Board)
                .WithMany()
                .HasForeignKey(x => x.BoardId),
                r => r.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId),
                j =>
                {
                    j.HasKey(x => x.Id);
                    j.ToTable("UserBoardMappings");
                });
        });
        b.Entity<UserBoardMapping>(entity =>
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_UserBoardMapping");

            entity.Property(x => x.UserId)
                .IsRequired();

            entity.Property(x => x.BoardId)
                .IsRequired();

            entity.HasIndex(x => new { x.UserId, x.BoardId })
                .IsUnique()
                .HasDatabaseName("IX_UserBoardMapping_UserId_BoardId");

            entity.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            entity.HasOne(x => x.Board)
                .WithMany()
                .HasForeignKey(x => x.BoardId);
        });

        foreach (var relationship in b.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
