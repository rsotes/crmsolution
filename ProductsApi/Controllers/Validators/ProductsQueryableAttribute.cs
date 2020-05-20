using Microsoft.Data.OData;
using Microsoft.Data.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Query.Validators;

namespace ProductsApi.Controllers.Validators
{
    public class ProductsQueryableAttribute : EnableQueryAttribute
    {
        public override void ValidateQuery(HttpRequestMessage request, ODataQueryOptions queryOptions)
        {
            if (queryOptions.OrderBy != null)
            {
                queryOptions.OrderBy.Validator = new ProductsOrderByValidator();
            }
            base.ValidateQuery(request, queryOptions);
        }
    }

    class ProductsOrderByValidator : OrderByQueryValidator
    {
        public override void Validate(OrderByQueryOption orderByOption, ODataValidationSettings validationSettings)
        {
            if (orderByOption.OrderByNodes.Any(node => node.Direction == OrderByDirection.Ascending))
            {
                throw new ODataException("you can not use 'asc' with this method call");
            }
            base.Validate(orderByOption, validationSettings);
        }
    }
}