using System.ComponentModel.DataAnnotations;

namespace DevTracker.Domain.Models;

public class Note
{
    [Key]
    public long Id { get; private set; }
    public string? Content { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; } = null;

    public Note(string content)
    {
        if (string.IsNullOrEmpty(content))
            throw new ArgumentNullException(nameof(content));

        Content = content;
    }
}
