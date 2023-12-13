using System.ComponentModel.DataAnnotations;
using Sakura.Core.Messages;

namespace Sakura.Application;

public class UpdateCustomerCommand : Command
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    public override bool IsValid()
    {
        return !Guid.Empty.Equals(Id) && Email is not null;
    }
}
