using Sakura.Core;
using Sakura.Domain.Validations;

namespace Sakura.Domain.Entities
{
    public class Customer : Entity
    {
        public new Guid Id { get; protected set; }
        public string Email { get; private set; }
        public override bool IsValid()
        {
            ResultValidation = new CustomerValidation().Validate(this);
            return ResultValidation.IsValid;
        }
    }
}