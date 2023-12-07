using Sakura.Application.Customers.Services.Models;

namespace Sakura.Application.Customers
{
    public interface CustomerService
    {
        Task<IEnumerable<CustomerModel>> Get();
    }
}