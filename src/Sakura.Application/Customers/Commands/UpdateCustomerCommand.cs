using System.ComponentModel.DataAnnotations;
using Sakura.Core.Messages;

namespace Sakura.Application;

public class UpdateCustomerCommand : Command
{

    public UpdateCustomerCommand(Guid customerId, string? email)
    {
        CustomerId = customerId;
        Email = email;
    }

    [Required]
    public Guid CustomerId { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    public override bool IsValid()
    {
        return !Guid.Empty.Equals(CustomerId) && Email is not null;
    }
}
