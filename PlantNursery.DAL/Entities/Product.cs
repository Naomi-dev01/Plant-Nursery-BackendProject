using System;
using System.Collections.Generic;

namespace PlantNursery.DAL.Entities;

public partial class Product
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int CategoryId { get; set; }

    public string Type { get; set; } = null!;

    public string? GrowingConditions { get; set; }

    public string? Color { get; set; }

    public string? Height { get; set; }

    public string? Care { get; set; }

    public string? MainUses { get; set; }

    public string? SpecialFeatures { get; set; }

    public string? Description { get; set; }

   
 public decimal Price { get; set; }
    public int? Stock { get; set; }

    public string? Image { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
   
}
