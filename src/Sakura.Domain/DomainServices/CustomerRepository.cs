using Sakura.Domain.Entities;

namespace Sakura.Domain.DomainServices
{
    public interface CustomerRepository
    {
        IEnumerable<Customer> Get();
        Customer Get(Guid id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}