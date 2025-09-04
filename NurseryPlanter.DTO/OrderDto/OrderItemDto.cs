using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.DTO.OrderDto
{
    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
       // public String Name { get; set; }
       // public string Image { get; set; }

        // public decimal Price { get; set; } // מחיר ליחידה

    }
}
