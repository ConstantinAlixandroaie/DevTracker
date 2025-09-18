using Microsoft.AspNetCore.Identity;

namespace DevTracker.Data.Models;

public class User : IdentityUser<long>
{
    public IEnumerable<Board>? Boards { get; set; }
    public IEnumerable<Board>? CreatedBoards { get; set; }
    public IEnumerable<TaskItem>? AssignedTasks { get; set; }
    public IEnumerable<TaskItem>? CreatedTasks { get; set; }
}

