using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs.Order;
using ShopManagementSystem.Application.Interfaces.Services;
using ShopManagementSystem.Domain.Entities.Orders;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly ProgramContext _context;
        private readonly IMapper _mapper;
        public OrderService(ProgramContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateOrderViewModel model)
        {
            var order = _mapper.Map<Order>(model);

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            _context.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (order is null)
                throw new Exception("No orders");

            return order;
        }
    }
}
