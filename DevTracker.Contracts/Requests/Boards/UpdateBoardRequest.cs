using System.ComponentModel.DataAnnotations;

namespace DevTracker.Contracts.Requests.Boards;

public class UpdateBoardRequest
{
    [Required]
    public long BoardId { get; set; }
    public string? Title { get; set; }
}
