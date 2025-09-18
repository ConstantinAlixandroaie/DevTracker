using DevTracker.Contracts.Requests.TaskItems;
using DevTracker.Contracts.Responses.TaskItems;

namespace DevTracker.Application.Interfaces;

/// <summary>
/// Provides operations for creating, retrieving, updating and deleting TaskItems
/// </summary>
public interface ITaskItemService
{
    /// <summary>
    /// Creates a new Task Item with the provided details.
    /// </summary>
    /// <param name="createTaskItemRequest"> The request object containing the task title</param>
    /// <returns>A task result that contains a<see cref="CreateTaskItemResponse"/></returns>
    Task<CreateTaskItemResponse> CreateTaskItemAsync(CreateTaskItemRequest createTaskItemRequest);

    /// <summary>
    /// Get all tasks.
    /// </summary>
    /// <returns> A task result that contains a <see cref="GetTaskItemsResponse"/> 
    /// with the collection of task items.</returns>
    Task<GetTaskItemsResponse> GetTaskItemsAsync();

    /// <summary>
    /// Deletes the specified task item.
    /// </summary>
    /// <param name="taskItemId"> The identifier of the task item to be deleted</param>
    /// <returns> A task result that contains a <see cref="DeleteTaskItemResponse"/>
    /// with the result of the deletion.</returns>
    Task<DeleteTaskItemResponse> DeleteTaskItemAsync(long taskItemId);

    /// <summary>
    /// Updates the specified task item.
    /// </summary>
    /// <param name="request"> The request object containing the task item Id
    /// and task status</param>
    /// <returns> A task result that contains a <see cref="UpdateTaskItemResponse"/>
    /// with the result of the update.</returns>
    Task<UpdateTaskItemResponse> UpdateTaskStatusAsync(UpdateTaskItemRequest request);
}
