using ProductsDomain.Orders;
using ProductServices.DTOs.Orders;
using ProductServices.Products.Extensions;

namespace ProductServices.extensions
{
    public static class OrderItemExtension
    {
        public static OrderItemDto ToOrderItemDto(this OrderItem orderItem)
        {
            return new OrderItemDto
            {
                Price = orderItem.Price,
                Product = orderItem.Product.ToProductDto(),
                Quantity = orderItem.Quantity
            };
        }
    }
}
