using ProductsDomain;
using ProductsDomain.Orders;
using ProductServices.DTOs;
using ProductServices.DTOs.Orders;
using System.Linq;

namespace ProductServices.extensions
{
    public static class OrderExtension
    {
        public static OrderResponse ToOrderDto(this Order order)
        {
            return new OrderResponse
            {
                Id = order.OrderId,
                Items = order.Items.Select(x => x.ToOrderItemDto()).ToList()
            };
        }
    }
}
