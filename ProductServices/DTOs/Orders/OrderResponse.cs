using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.DTOs.Orders
{
    public class OrderResponse
    {
        public int Id { get; set; }

        public string OrderNumber { get; set; }

        public List<OrderItemDto> Items { get; set; }
    }
}
