using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Sakura.Domain.DomainServices;
using Sakura.Domain.Entities;

namespace Sakura.Data.Repositories
{
    public class CustomerRepositoryImp : CustomerRepository
    {
        private readonly SakuraDbReadOnlyContext _readonlyDbContext;
        private readonly SakuraDbContext _context;
        public CustomerRepositoryImp(SakuraDbReadOnlyContext readonlyDbContext, SakuraDbContext context)
        {
            _readonlyDbContext = readonlyDbContext ?? throw new NullReferenceException(nameof(readonlyDbContext));
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public IEnumerable<Customer> Get()
        {
            return _readonlyDbContext.Customers
                                     .AsNoTracking()
                                     .ToList();
        }
        public Customer? GetByEmail(string email)
        {
            return _readonlyDbContext.Customers
                                     .AsNoTracking()
                                     .FirstOrDefault(_ => _.Email.Equals(email));
        }
        public Customer? Get(Guid id)
        {
            return _context.Customers.Find(id);
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }
        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }
        public void Remove(Customer customer)
        {
            _context.Customers.Remove(customer);
        }
    }
}