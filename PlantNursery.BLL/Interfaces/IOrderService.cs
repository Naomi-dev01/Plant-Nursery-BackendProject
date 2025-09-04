using PlantNursery.DAL.Entities;
using PlantNursery.DAL.Interfaces;
using PlantNursery.DTO.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrder(CreateOrderDto orderDto);
        //Task<OrderResponseDto> UpdateOrder(CreateOrderDto orderDto);
        Task<List<OrderResponseDto>> GetOrdersByUserId(int userId);
        Task<Order?> DeleteOrder(int orderId);
    }
}
