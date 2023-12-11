using AutoMapper;
using Sakura.Application.Customers.Services.Models;
using Sakura.Domain.Entities;

namespace Sakura.Application.Profiles
{
    public class CustomerProfile : Profile
    {
        protected internal CustomerProfile() : base()
        {
            CreateMap<Customer, CustomerModel>();
        }
    }
}