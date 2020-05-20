using Infrastructure;
using ProductServices;
using ProductServices.DTOs;
using ProductServices.DTOs.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductsApi.Controllers
{
    [RoutePrefix("customers")]
    public class CustomerController : ApiController
    {
        private readonly CustomerService customerService;

        private readonly IUnitOfWork uow;

        public CustomerController(CustomerService service, IUnitOfWork uow)
        {
            customerService = service;
            this.uow = uow;
        }

        [Route("")]
        public  Task PostCustomer(AddCustomerRequest dto)
        {
            var res = Task.Run(() =>
            {
                customerService.Add(dto);
                uow.Commit();
            });
            
            return res;
        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            return await Task.FromResult(Json(await customerService.Find(id)));
        }
    }
}
