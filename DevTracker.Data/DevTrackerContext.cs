using DevTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTracker.Data
{
    public class DevTrackerContext : DbContext
    {
        public DevTrackerContext(DbContextOptions<DevTrackerContext> options) : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems {  get; set; }
        public DbSet<Note> Notes {  get; set; }
    }
}
