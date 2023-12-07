using Microsoft.AspNetCore.Mvc;
using Sakura.Application.Customers;

namespace Sakura.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly CustomerService _customerService;

    public CustomerController(ILogger<CustomerController> logger,
    CustomerService customerService)
    {
        _logger = logger ?? throw new NullReferenceException(nameof(logger));
        _customerService = customerService ?? throw new NullReferenceException(nameof(customerService));
    }

    [HttpGet(Name = "Get")]
    public async Task<ActionResult> Get()
    {
        var customers = await _customerService.Get();
        return Ok(customers);
    }
}
