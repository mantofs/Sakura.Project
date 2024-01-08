using Sakura.Domain.Entities;

namespace Sakura.Domain.DomainServices
{
    public interface CustomerRepository
    {
        IEnumerable<Customer> Get();
        Customer Get(Guid id);
        Customer? GetByEmail(string email);
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}