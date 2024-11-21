using Demo.Application.DTOs.Customer.Requests.Commands;
using FluentValidation;

namespace Demo.Application.Validations
{
    public class CreateCustomerDtoValidator : AbstractValidator<AddCustomerCommandDto>
    {
        public CreateCustomerDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is required");

            RuleFor(x => x.Name)
                .Length(2, 50)
                .WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Birth date is required");

            RuleFor(x => x.BirthDate)
                .GreaterThan(DateTime.MinValue)
                .WithMessage("The date must be a valid date.");
        }
    }
}
