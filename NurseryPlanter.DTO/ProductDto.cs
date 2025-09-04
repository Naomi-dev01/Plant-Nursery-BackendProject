using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.DTO
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string CategoryName { get; set; } // שם הקטגוריה במקום ID
        public string? GrowingConditions { get; set; }
        public string? Color { get; set; }
        public string? Height { get; set; }
        public string? Care { get; set; }
        public string? MainUses { get; set; }
        public string? SpecialFeatures { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }


}
