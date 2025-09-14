using DevTracker.Domain.DTOs;
using FluentValidation;

namespace DevTracker.Data.Validators;

public class CreateTaskItemRequestValidator : AbstractValidator<CreateTaskItemRequest>
{
    internal CreateTaskItemRequestValidator()
    {
        RuleFor(x => x.TaskItemTitle).NotNull().NotEmpty();
    }
}
