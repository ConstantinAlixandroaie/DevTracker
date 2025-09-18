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
        b.Entity<Board>()
            .HasOne(x => x.Owner)
            .WithMany(x => x.Boards)
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        b.Entity<Board>()
            .HasOne(x => x.CreatedBy)
            .WithMany(x => x.CreatedBoards)
            .HasForeignKey(x => x.CreatedById)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        b.Entity<TaskItem>()
           .HasOne(x => x.Assignee)
           .WithMany(x => x.AssignedTasks)
           .HasForeignKey(x => x.AssigneeId)
           .OnDelete(DeleteBehavior.Restrict)
           .IsRequired();
        b.Entity<TaskItem>()
           .HasOne(x => x.CreatedBy)
           .WithMany(x => x.CreatedTasks)
           .HasForeignKey(x => x.CreatedById)
           .OnDelete(DeleteBehavior.Restrict)
           .IsRequired();
    }
}
