namespace PlantNursery.API.Models.OrderRequests
{
    public class OrderItem
    {
        public Guid ProductId { get; set; } // מזהה המוצר
        public int Quantity { get; set; } // כמות המוצר בהזמנה
        public decimal Price { get; set; } // מחיר ליחידה של המוצר
        // ניתן להוסיף כאן תכונות נוסxxx אם יש צורך, כמו שם המוצר או תמונה
        // לדוגמה:
        // public string ProductName { get; set; }
        // public string ProductImage { get; set; }
    }
}
