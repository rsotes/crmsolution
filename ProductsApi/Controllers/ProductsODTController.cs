using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using ProductsDomain.Products;
using Microsoft.Data.OData;
using ProductServices;
using Infrastructure;
using ProductServices.DTOs.Products;
using ProductsApi.Controllers.Validators;

namespace ProductsApi.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ProductsDomain.Products;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Product>("Products1");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ProductsODTController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        private ProductService productServices;

        private IUnitOfWork UOW;

        public ProductsODTController(ProductService productService, IUnitOfWork uow)
        {
            productServices = productService;
            UOW = uow;
        }

        // GET: odata/Products
        //[EnableQueryAttribute(AllowedQueryOptions = AllowedQueryOptions.OrderBy | AllowedQueryOptions.Expand)]
        [ProductsQueryableAttribute(AllowedQueryOptions = AllowedQueryOptions.OrderBy | AllowedQueryOptions.Select | AllowedQueryOptions.Expand)]
        public async Task<IHttpActionResult> GetProductsODT(ODataQueryOptions<ProductResponseDto> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }
            return await Task.FromResult(Ok(productServices.AsQueriable(queryOptions.SelectExpand != null)));
        }

        // GET: odata/Products(5)
        [ProductsQueryableAttribute(AllowedQueryOptions = AllowedQueryOptions.OrderBy | AllowedQueryOptions.Select | AllowedQueryOptions.Expand)]
        public async Task<IHttpActionResult> GetProductsODT([FromODataUri] int key, ODataQueryOptions<ProductResponseDto> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }
            ;
            return Ok<ProductResponseDto>(await productServices.FindProduct(key));
        }

        // PUT: odata/Products1(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<AddProductDto> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(product);

            // TODO: Save the patched entity.

            // return Updated(product);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Products1
        public async Task<IHttpActionResult> Post(ProductResponseDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (product == null) return BadRequest("Product is required");
            await productServices.AddAsync(new AddProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.Category?.Id ?? 0
            });
            UOW.Commit();
            return Created(product);
        }

        // PATCH: odata/Products1(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ProductResponseDto> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await productServices.FindProduct(key);
            delta.Patch(product);

            // TODO: Save the patched entity.

            return Updated(product);
        }

        // DELETE: odata/Products1(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
