using FluentValidation;
using Sakura.Domain.Entities;

namespace Sakura.Domain.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(employee => employee.Email)
            .NotEmpty()
            .WithMessage("O email do cliente não pode estar vazio");
        }
    }
}