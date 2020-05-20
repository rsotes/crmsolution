using ProductsDomain;
using ProductsDomain.Customers;
using ProductServices.DTOs;
using ProductServices.DTOs.Customers;

namespace ProductServices.extensions
{
    public static class CustomerExtension
    {
        public static CustomerResponse ToCustomerDto(this Customer customer)
        {
            return new CustomerResponse
            {
                Id = customer.CustomerId,
                Name = customer.Name,
            };
        }
    }
}
