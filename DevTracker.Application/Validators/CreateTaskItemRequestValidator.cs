using DevTracker.Domain.DTOs;
using FluentValidation;

namespace DevTracker.Application.Validators;

public class CreateTaskItemRequestValidator : AbstractValidator<CreateTaskItemRequest>
{
    public CreateTaskItemRequestValidator()
    {
        RuleFor(x => x.TaskItemTitle).NotNull().NotEmpty();
    }
}
