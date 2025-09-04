using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.DTO.OrderDto
{
    public class OrderDetailsResponseDto
    {
        
            //public int Id { get; set; }
            public Guid ProductId { get; set; }
            public int Quantity { get; set; }
           public decimal Price { get; set; }  // מחיר ליחידה
            public decimal LineTotal => Price * Quantity;
       // public string ?Name { get; set; }
       // public string? Image { get; set; }



    }
}
