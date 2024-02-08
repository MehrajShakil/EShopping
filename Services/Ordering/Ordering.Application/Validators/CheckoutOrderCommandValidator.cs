using FluentValidation;
using Ordering.Application.Commands;

namespace Ordering.Application.Validators;

public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandValidator()
    {
        RuleFor(order => order.UserName)
            .NotEmpty()
            .WithMessage($"UserName is required")
            .MaximumLength(70)
            .WithMessage("Username must not exceed 70 character");
    }
}
