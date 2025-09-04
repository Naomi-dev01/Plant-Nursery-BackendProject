namespace PlantNursery.API.Models
{
    public class ProductRequest
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string CategoryName { get; set; } = null!; // שם הקטגוריה במקום ID
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
