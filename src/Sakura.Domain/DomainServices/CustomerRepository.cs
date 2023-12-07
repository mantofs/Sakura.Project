using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sakura.Domain.Entities;

namespace Sakura.Domain.DomainServices
{
    public interface CustomerRepository
    {
        IAsyncEnumerable<Customer> GetAsync();
    }
}