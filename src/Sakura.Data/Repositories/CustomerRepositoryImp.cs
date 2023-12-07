using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sakura.Domain.DomainServices;
using Sakura.Domain.Entities;

namespace Sakura.Data.Repositories
{
    public class CustomerRepositoryImp : CustomerRepository
    {
        private readonly SakuraDbReadOnlyContext _readonlyDbContext;
        public CustomerRepositoryImp(SakuraDbReadOnlyContext readonlyDbContext)
        {
            _readonlyDbContext = readonlyDbContext ?? throw new NullReferenceException(nameof(readonlyDbContext));
        }

        public IAsyncEnumerable<Customer> GetAsync()
        {
            return _readonlyDbContext.Customers
                                     .AsNoTracking()
                                     .AsAsyncEnumerable();
        }
    }
}