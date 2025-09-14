using DevTracker.Domain.DTOs;
using FluentValidation;

namespace DevTracker.Data.Validators;

public class UpdateTaskItemRequestValidator : AbstractValidator<UpdateTaskItemRequest>
{
    public UpdateTaskItemRequestValidator()
    {
        RuleFor(x => x.TaskId).NotEqual(0);
        RuleFor(x => x.Status).IsInEnum();
    }
}
