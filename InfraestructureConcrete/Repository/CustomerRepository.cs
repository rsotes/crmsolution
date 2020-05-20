﻿using Infrastructure;
using Infrastructure.Repositories;
using ProductsDomain;
using ProductsDomain.Customers;
using ProductsDomain.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraestructureConcrete.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbSet<Customer> customers;

        public CustomerRepository(IUnitOfWork uow)
        {
            customers = uow.Context.Set<Customer>();
        }

        public void Add(Customer entity)
        {
            customers.Add(entity);
        }

        public Task AddAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public async void Delete(int id)
        {
            var entity = await customers.FindAsync(id);
            if (entity == null) throw new Exception("Customer not found");
            customers.Remove(entity);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> FindASync(int id)
        {
            return await customers.FindAsync(id);
        }

        public IQueryable<Customer> AsQueryable()
        {
            return customers.AsQueryable();
        }

        public async Task<IEnumerable<Customer>> QueryAsync(int index, int total)
        {
            return await customers.AsQueryable().OrderBy(x => x.CustomerId).Skip(index).Take(total).ToListAsync();
        }

        public void Update(Customer entity)
        {
            throw new Exception();
        }

        public Task UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
