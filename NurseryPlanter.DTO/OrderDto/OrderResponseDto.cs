using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PlantNursery.DTO.OrderDto;

namespace PlantNursery.DTO.OrderDto
{
    public class OrderResponseDto
    {
       
            public int Id { get; set; }
            public int UserId { get; set; }
            public DateTime OrderDate { get; set; }
        public List<OrderDetailsResponseDto> Item { get; set; } = new();
        public decimal Total => Item?.Sum(i => i.Price * i.Quantity) ?? 0;

    }
}
