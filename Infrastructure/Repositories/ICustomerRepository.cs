using ProductsDomain;
using ProductsDomain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface ICustomerRepository : IRepositoryRead<Customer>, IRepositoryWrite<Customer>
    {
    }
}
