
using PlantNursery.DTO.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.DTO.OrderDto
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
     //   public DateTime OrderDate { get; set; }
      public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
        //public decimal Price { get; set; }
    }
}
