using ProductsDomain.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsDomain.Products.Extensions
{
    public static class ValidateCategoryExtension
    {
        public static void ValidateName(this Category category)
        {
            if (string.IsNullOrEmpty(category.Name)) throw new InvalidDomainException("Name is required");
        }
    }
}
