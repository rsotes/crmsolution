using Infrastructure;
using ProductServices;
using ProductServices.DTOs;
using ProductServices.DTOs.Products;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProductsApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private readonly ProductService service;

        private readonly IUnitOfWork uow;

        public ProductsController(ProductService service, IUnitOfWork uow)
        {
            this.service = service;
            this.uow = uow;
        }

        [Route("")]
        public async Task<IHttpActionResult> GetProducts(int index, int max)
        {
            return await Task.FromResult(Json(await service.FindProducts(index, max)));
        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            return await Task.FromResult(Json(await service.FindProduct(id)));
            
        }

        [Route("")]
        public async void Post(AddProductDto dto)
        {
            await service.AddAsync(dto);
            uow.Commit();
        }
    }
}
