using System.ComponentModel.DataAnnotations;

namespace DevTracker.Data.Models;

public class Note
{
    [Key]
    public long Id { get; private set; }
    [Required]
    [StringLength(2000)]
    public string? Content { get; set; }
    [Required]
    public long TaskItemId { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
}
