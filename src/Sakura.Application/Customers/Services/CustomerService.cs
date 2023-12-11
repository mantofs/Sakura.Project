using Sakura.Application.Customers.Services.Models;

namespace Sakura.Application.Customers
{
    public interface CustomerService
    {
        IEnumerable<CustomerModel> Get();
    }
}