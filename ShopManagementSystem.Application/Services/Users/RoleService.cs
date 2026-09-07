using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Application.DTOs;
using ShopManagementSystem.Application.Interfaces.Users;
using ShopManagementSystem.Domain.Entities.Identity;
using ShopManagementSystem.Infrastructure.Data.Context;

namespace ShopManagementSystem.Application.Services.Users;

public class RoleService : IRoleService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public RoleService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> ExistsRoleByIdAsync(int id)
    {
        return await _context.Roles.AnyAsync(r => r.Id == id);
    }

    public async Task<List<RoleViewModel>> GetAllRolesAsync()
    {
        List<Role> roles = await _context.Roles.ToListAsync();

        return _mapper.Map<List<RoleViewModel>>(roles);
    }

}
