using DevTracker.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace DevTracker.Data.Models;

public class TaskItem
{
    public long Id { get; private set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    public Status Status { get; set; } = Status.ToDo;
    public List<Note> Notes { get; set; } = new();
    public List<string> Tags { get; set; } = new();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
}
