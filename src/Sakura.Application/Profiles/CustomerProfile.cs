using AutoMapper;
using Sakura.Application.Customers.Services.Models;
using Sakura.Domain.Entities;

namespace Sakura.Application.Profiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerModel>();
            //CreateMap<IEnumerable<Customer>, IEnumerable<CustomerModel>>();
        }
    }
}