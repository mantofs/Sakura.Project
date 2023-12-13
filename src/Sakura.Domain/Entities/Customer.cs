using Sakura.Core;
using Sakura.Domain.Validations;

namespace Sakura.Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer(string email) : base()
        {
            Email = email;
        }
        public new Guid Id { get; protected set; }
        public string Email { get; private set; }

        public static Customer Create(string email) => new Customer(email);

        public override bool IsValid()
        {
            ResultValidation = new CustomerValidation().Validate(this);
            return ResultValidation.IsValid;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }
    }
}