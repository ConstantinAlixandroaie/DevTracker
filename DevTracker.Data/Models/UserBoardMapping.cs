namespace DevTracker.Data.Models;

public class UserBoardMapping
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public long BoardId { get; set; }
    public Board? Board { get; set; }
}