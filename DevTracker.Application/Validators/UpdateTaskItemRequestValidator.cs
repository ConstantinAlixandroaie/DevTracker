using DevTracker.Contracts.Requests;
using DevTracker.Data.Enums;
using FluentValidation;

namespace DevTracker.Application.Validators;

public class UpdateTaskItemRequestValidator : AbstractValidator<UpdateTaskItemRequest>
{
    public UpdateTaskItemRequestValidator()
    {
        RuleFor(x => x.TaskId).NotEqual(0);
        RuleFor(x => x.Status).NotEqual(Status.None);
    }
}
