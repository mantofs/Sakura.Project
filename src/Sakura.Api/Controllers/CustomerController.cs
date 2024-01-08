using Microsoft.AspNetCore.Mvc;
using Sakura.Application;
using Sakura.Application.Customers;
using Sakura.Application.Customers.Services.Models;
using Sakura.Core.Communication;
using Sakura.Core.Messages.CommonMessages.Notifications;

namespace Sakura.Api.Controllers;

[ApiController]
[Route("[controller]/v1")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly CustomerService _customerService;
    private readonly CommunicationHandler _communicator;
    private readonly INotificationOutputHandler _notificationHandler;
    public CustomerController(ILogger<CustomerController> logger,
    CustomerService customerService,
    CommunicationHandler communicator,
    INotificationOutputHandler notificationHandler)
    {
        _logger = logger ?? throw new NullReferenceException(nameof(logger));
        _customerService = customerService ?? throw new NullReferenceException(nameof(customerService));
        _communicator = communicator ?? throw new NullReferenceException(nameof(communicator));
        _notificationHandler = notificationHandler ?? throw new NullReferenceException(nameof(notificationHandler));
    }

    [HttpGet("get", Name = "Get")]
    public ActionResult Get()
    {
        var customers = _customerService.Get();
        return Ok(customers);
    }

    [HttpPost("create", Name = "Create")]
    public async Task<ActionResult> CreateAsync([FromBody] CustomerBodyModel model)
    {
        var command = new CreateCustomerCommand(email: model.Email);

        await _communicator.PublishCommandAsync(command);

        if (_notificationHandler.HasNotifications(out IEnumerable<string> messages))
            return BadRequest(messages);

        return Ok();
    }

    [HttpPut("{customerId}/update", Name = "Update")]
    public async Task<ActionResult> Update([FromRoute] Guid customerId, [FromBody] CustomerBodyModel model)
    {
        var command = new UpdateCustomerCommand(customerId: customerId, email: model.Email);

        await _communicator.PublishCommandAsync(command);

        if (_notificationHandler.HasNotifications(out IEnumerable<string> messages))
            return BadRequest(messages);

        return Ok();
    }

    [HttpDelete("{customerId}/delete", Name = "Delete")]
    public async Task<ActionResult> Delete([FromRoute] Guid customerId)
    {
        var command = new DeleteCustomerCommand(customerId: customerId);

        await _communicator.PublishCommandAsync(command);

        if (_notificationHandler.HasNotifications(out IEnumerable<string> messages))
            return BadRequest(messages);

        return Ok();
    }
}
