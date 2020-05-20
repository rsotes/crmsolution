using ProductsDomain.Products;
using ProductServices.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;

namespace ProductsApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<ProductResponseDto>("ProductsOdt");
            modelBuilder.EntitySet<CategoryResponseDto>("CategoryOdt");
            config.Routes.MapODataServiceRoute("odata", "odata", modelBuilder.GetEdmModel());
        }
    }
}
