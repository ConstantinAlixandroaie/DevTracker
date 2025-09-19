using System.ComponentModel.DataAnnotations;

namespace DevTracker.Contracts.Requests.Boards;

public class CreateBoardRequest
{
    [Required]
    public string BoardTitle { get; set; } = "";
    [Required]
    public long UserId { get; set; }
}
