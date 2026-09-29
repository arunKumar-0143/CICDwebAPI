using FluentValidation;

namespace CICDProject.Application.Validators;

public class CreateCustomerCommandValidator : AbstractValidator<CICDProject.Application.Features.Customers.Commands.CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(command => command.RequestPayload.CustomerCode)
            .NotEmpty().WithMessage("Customer code is required.")
            .MaximumLength(50).WithMessage("Customer code cannot exceed 50 characters.");

        RuleFor(command => command.RequestPayload.CompanyName)
            .NotEmpty().WithMessage("Company name is required.")
            .MaximumLength(200).WithMessage("Company name cannot exceed 200 characters.");

        RuleFor(command => command.RequestPayload.ContactEmail)
            .NotEmpty().WithMessage("Contact email is required.")
            .EmailAddress().WithMessage("A valid contact email must be provided.");
    }
}
