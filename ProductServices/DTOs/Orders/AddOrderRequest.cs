using System.Collections.Generic;

namespace ProductServices.DTOs.Orders
{
    public class AddOrderRequest
    {
        public int CustomerId { get; set; }

        public List<OrderItemDto> Items { get; set; }
    }
}
