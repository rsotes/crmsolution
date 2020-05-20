using Infrastructure.Repositories;
using System;
using System.Threading.Tasks;
using ProductServices.extensions;
using ProductsDomain.Customers;
using System.Linq;
using ProductServices.DTOs.Customers;
using System.Collections.Generic;

namespace ProductServices
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository repository)
        {
            customerRepository = repository;
        }

        public void Add(AddCustomerRequest customer)
        {
            if (customer.Addresses == null || customer.Addresses.Count == 0) throw new Exception("Address is required");
            customerRepository.Add(new Customer(customer.Name, 
                customer.Addresses.Select(x => new Address(x.Street, x.City, x.State, x.Country, x.PostalCode)).ToList(), 
                customer.Phone.PhoneNumber));
        }

        public async Task<CustomerResponse> Find(int id)
        {
            var customer = await customerRepository.FindASync(id);
            if (customer == null) throw new Exception("Customer not found");
            return customer.ToCustomerDto();
        }

        public async Task<IEnumerable<Customer>> FindAll(int index, int max)
        {
            return await customerRepository.QueryAsync(index, max);
        }
    }
}
