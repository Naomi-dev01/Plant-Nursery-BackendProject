using AutoMapper;
using PlantNursery.BLL.Interfaces;
using PlantNursery.DAL.Entities;
using PlantNursery.DAL.Interfaces;
using PlantNursery.DTO.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrder _orderRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrder orderRepository, IMapper mapper, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<OrderResponseDto> CreateOrder(CreateOrderDto orderDto)
        {
            if (orderDto == null) throw new ArgumentNullException(nameof(orderDto));

            if (orderDto.OrderItems == null || orderDto.OrderItems.Count == 0)
            {
                throw new InvalidOperationException("Order must contain at least one item.");
            }

            var order = _mapper.Map<Order>(orderDto);
            order.OrderDate = DateTime.UtcNow;

            foreach (var od in order.OrderDetails)
            {
                if (od.Quantity <= 0)
                {
                    throw new InvalidOperationException("Order item quantity must be greater than zero.");
                }

                var product = await _productRepository.GetProductById(od.ProductId);
                if (product == null)
                {
                    throw new InvalidOperationException($"Product with ID {od.ProductId} does not exist.");
                }
                od.Price = product.Price;
            }
            var savedorder = await _orderRepository.CreateOrder(order);
            return _mapper.Map<OrderResponseDto>(savedorder);


        }

        public async Task<List<OrderResponseDto>> GetOrdersByUserId(int userId)
        {
            if (userId < 0) throw new ArgumentException("Invalid user ID.", nameof(userId));
            var orders = await _orderRepository.GetOrderByUserId(userId);
            return _mapper.Map<List<OrderResponseDto>>(orders);
        }

    public async Task<Order?> DeleteOrder(int orderId)
        {
            if (orderId <= 0) throw new ArgumentException("Invalid order ID.", nameof(orderId));
            return await _orderRepository.DeleteOrder(orderId);
        }

    }
}
