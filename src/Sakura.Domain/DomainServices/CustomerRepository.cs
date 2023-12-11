using Sakura.Domain.Entities;

namespace Sakura.Domain.DomainServices
{
    public interface CustomerRepository
    {
        IEnumerable<Customer> Get();
    }
}