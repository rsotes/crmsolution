using ProductsDomain;
using ProductsDomain.Products;
using ProductServices.DTOs;
using ProductServices.DTOs.Products;
using ProductServices.DTOs.Products.Extensions;

namespace ProductServices.Products.Extensions
{
    public static class ProductExtension
    {
        public static ProductResponseDto ToProductDto(this Product product)
        {
            return new ProductResponseDto
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category?.ToCategoryDto()
            };
        }
    }
}
