using DevTracker.Data.Configurations;
using DevTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTracker.Data;

public class DevTrackerContext : DbContext
{
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<Note> Notes { get; set; }

    public DevTrackerContext(DbContextOptions<DevTrackerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaskItemConfiguration());
    }
}
