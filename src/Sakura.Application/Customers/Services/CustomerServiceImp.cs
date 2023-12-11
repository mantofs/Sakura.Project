using AutoMapper;
using Sakura.Application.Customers.Services.Models;
using Sakura.Domain.DomainServices;

namespace Sakura.Application.Customers
{
    public class CustomerServiceImp : CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerServiceImp(CustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public IEnumerable<CustomerModel> Get()
        {
            var customers = _customerRepository.Get();

            return _mapper.Map<IEnumerable<CustomerModel>>(customers);
        }
    }
}