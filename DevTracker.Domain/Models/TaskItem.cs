using DevTracker.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace DevTracker.Domain.Models;

public class TaskItem
{
    [Key]
    public long Id { get; private set; }
    public string Title { get; set; } = null!;
    public Status Status { get; set; } = Status.ToDo;
    public List<Note> Notes { get; set; } = new();
    public List<string> Tags { get; set; } = new();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
}
