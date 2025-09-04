using PlantNursery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.DAL.Interfaces
{
   

    public interface IOrder
    {
        Task<Order> CreateOrder(Order order);
      //  Task<Order> PutOrder(Order order);
        Task<List<Order>> GetOrderByUserId(int useerId);
        Task<Order?> DeleteOrder(int orderId);
    }
}
