using System.ComponentModel.DataAnnotations;
using Sakura.Core.Messages;

namespace Sakura.Application;

public class DeleteCustomerCommand : Command
{
    public DeleteCustomerCommand(Guid customerId)
    {
        CustomerId = customerId;
    }

    [Required]
    public Guid CustomerId { get; set; }

    public override bool IsValid()
    {
        return !Guid.Empty.Equals(CustomerId);
    }
}