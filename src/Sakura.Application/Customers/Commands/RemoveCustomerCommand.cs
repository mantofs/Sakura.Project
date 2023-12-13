using System.ComponentModel.DataAnnotations;
using Sakura.Core.Messages;

namespace Sakura.Application;

public class RemoveCustomerCommand : Command
{
    [Required]
    public Guid Id { get; set; }

    public override bool IsValid()
    {
        return !Guid.Empty.Equals(Id);
    }
}