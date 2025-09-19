using DevTracker.Data.Configurations;
using DevTracker.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevTracker.Data;

public class DevTrackerContext : IdentityDbContext<User, IdentityRole<long>, long>
{
    public DbSet<Board> Boards { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TagTaskItemMapping> TagTaskItemMappings { get; set; }
    public DbSet<UserBoardMapping> UserBoardMappings { get; set; }

    public DevTrackerContext(DbContextOptions<DevTrackerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);
        new BoardsConfiguration().Configure(b.Entity<Board>());
        new TaskItemsConfiguration().Configure(b.Entity<TaskItem>());
        new NotesConfiguration().Configure(b.Entity<Note>());
        new TagsConfiguration().Configure(b.Entity<Tag>());
        new TagTaskItemMappingsConfiguration().Configure(b.Entity<TagTaskItemMapping>());
        new UserBoardMappingsConfiguration().Configure(b.Entity<UserBoardMapping>());

        foreach (var relationship in b.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
