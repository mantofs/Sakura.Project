using System.ComponentModel.DataAnnotations;
using Sakura.Core.Messages;

namespace Sakura.Application;
public class CreateCustomerCommand : Command
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    public CreateCustomerCommand(string? email)
    {
        Email = email;
    }

    public override bool IsValid()
    {
        return Email is not null;
    }
}