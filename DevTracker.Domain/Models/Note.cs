namespace DevTracker.Domain.Models;

public class Note
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string? Content { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public Note(string content)
    {
        if(string.IsNullOrEmpty(content)) 
            throw new ArgumentNullException(nameof(content));

        Content = content;
    }
}
