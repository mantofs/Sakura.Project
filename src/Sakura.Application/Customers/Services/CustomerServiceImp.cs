using Sakura.Application.Customers.Services.Models;
using Sakura.Domain.DomainServices;

namespace Sakura.Application.Customers
{
    public class CustomerServiceImp : CustomerService
    {
        private CustomerRepository _customerRepository;
        public CustomerServiceImp(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Task<IEnumerable<CustomerModel>> Get()
        {
            var customers = _customerRepository.GetAsync();
            return _mapper.Map<IEnumerable<CustomerModel>>(customers);
        }
    }
}