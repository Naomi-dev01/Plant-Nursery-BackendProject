using PlantNursery.DTO.UserDto;
namespace PlantNursery.API.Models.OrderRequests
{
    public class CreateOrderRequst
    {
        public int UserId { get; set; } // מזהה המשתמש
        public DateTime OrderDate { get; set; } // תאריך ההזמנה
        public UserCreateDto UserDetails { get; set; } // פרטי המשתמש
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); // פרטי הפריטים בהזמנה
        // ניתן להוסיף כאן תכונות נוסxxx אם יש צורך, כמו כתובת למשלוח או הערות להזמנה
    }
}
