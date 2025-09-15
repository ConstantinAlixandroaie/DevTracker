using System.ComponentModel.DataAnnotations;

namespace DevTracker.Data.Models;

public class Note
{
    [Key]
    public long Id { get; private set; }
    [Required]
    public string? Content { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; } = null;
}
