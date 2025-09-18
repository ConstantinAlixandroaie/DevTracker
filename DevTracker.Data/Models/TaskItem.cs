using DevTracker.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace DevTracker.Data.Models;

public class TaskItem
{
    [Key]
    public long Id { get; private set; }
    [Required]
    [StringLength(255)]
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    [Required]
    public Status Status { get; set; } = Status.ToDo;
    public List<Note> Notes { get; set; } = [];
    public List<Tag> Tags { get; set; } = [];
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
    public long CreatedById { get; set; }
    public User? CreatedBy { get; set; }
    public long AssigneeId { get; set; }
    public User? Assignee { get; set; }
    public long BoardId { get; set; }
    public Board? Board { get; set; }
}
