using Customer.Api.Models;
using FluentValidation;

namespace Customer.Api.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerModel>
    {
        public CustomerValidator()
        {

            RuleFor(c => c.Code)
                .Length(2, 50)
                .WithMessage("{PropertyName} Length between 2 y 500 characters")
                .NotNull().WithMessage("Description cannot be null");
        }
    }
}