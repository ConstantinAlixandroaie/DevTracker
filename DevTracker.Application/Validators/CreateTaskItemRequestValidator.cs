using DevTracker.Contracts.Requests;
using FluentValidation;

namespace DevTracker.Application.Validators;

public class CreateTaskItemRequestValidator : AbstractValidator<CreateTaskItemRequest>
{
    public CreateTaskItemRequestValidator()
    {
        RuleFor(x => x.TaskItemTitle).NotNull().NotEmpty();
    }
}
