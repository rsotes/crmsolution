using ProductsDomain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.DTOs.Products.Extensions
{
    public static class CategoryExtension
    {
        public static CategoryResponseDto ToCategoryDto(this Category category)
        {
            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
