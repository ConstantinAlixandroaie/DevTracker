using DevTracker.Data.Models;

namespace DevTracker.Contracts.Responses.TaskItems;

public class GetTaskItemsResponse : Response
{
    public IEnumerable<TaskItem>? TaskItems { get; set; }

    public GetTaskItemsResponse(Result result, IEnumerable<TaskItem>? taskItems, string? errorMessage = null) : base(result, errorMessage)
    {
        TaskItems = taskItems;
    }
    public static GetTaskItemsResponse Success(Result result, IEnumerable<TaskItem>? taskItems) => new(result, taskItems, null);
}
