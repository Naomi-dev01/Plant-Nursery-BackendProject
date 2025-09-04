using Microsoft.EntityFrameworkCore;
using PlantNursery.DAL.Context;
using PlantNursery.DAL.Entities;
using PlantNursery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.DAL.Repositories
{
    public class OrderRepository: IOrder
    {
        private readonly PlantNurseryDbContext _context;

        public OrderRepository(PlantNurseryDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrder (Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> PutOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<List<Order>> GetOrderByUserId(int userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderDetails)
                .ToListAsync();
        }

        public async Task<Order?> DeleteOrder(int orderId)
        {
            var order = await _context.Orders.Include(o => o.OrderDetails)
    .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return null; // Order not found
            }
            if (DateTime.UtcNow - order.OrderDate > TimeSpan.FromDays(3))
            {
                throw new InvalidOperationException("Cannot delete an order older than 3 days.");
            }
            _context.OrderDetails.RemoveRange(order.OrderDetails);
            _context.Orders.Remove(order);
            try
            {
await _context.SaveChangesAsync();
            }catch(DbUpdateException ex)
            {
                throw new Exception($"DB Error: {ex.InnerException?.Message}", ex);

            }


            return order; // Return the deleted order
        }
    }
}
