using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ShopManagementSystem.Application.DTOs.Users;
using ShopManagementSystem.Application.Interfaces.Users;
using ShopManagementSystem.Application.Users.Dtos;
using ShopManagementSystem.Domain.Entities.Identity;
using ShopManagementSystem.Domain.Repositories;

namespace ShopManagementSystem.Application.Users;

public sealed class UserService(
    IPasswordHasher<User> passwordHasher,
    IUserRepository userRepository,
    IMapper mapper
    ) : IUserService
{
    public async Task<UserDto> CreateAsync(CreateUserDto createUserDto)
    {
        User user = mapper.Map<User>(createUserDto);

        user.PasswordHash = passwordHasher.HashPassword(user, createUserDto.Password);

        await userRepository.CreateAsync(user);

        UserDto userDto = mapper.Map<UserDto>(user);
        return userDto;
    }

    public async Task DeleteAsync(Guid id)
    {
        await userRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(Guid id, UpdateUserDto updateUserDto)
    {
        User user = mapper.Map<User>(updateUserDto);

        if (!string.IsNullOrEmpty(updateUserDto.NewPassword))
        {
            user.PasswordHash = passwordHasher.HashPassword(user, updateUserDto.NewPassword);
        }

        await userRepository.UpdateAsync(id, user);

    }

    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        User user = await userRepository.GetByIdAsync(id);

        UserDto userDto = mapper.Map<UserDto>(user);

        return userDto;
    }

    public async Task<UsersCollectionDto> GetAllAsync()
    {
        IEnumerable<User> users = await userRepository.GetAllAsync();

        IReadOnlyCollection<UserDto> userDtos = mapper.Map<IReadOnlyCollection<UserDto>>(users);

        var usersCollectionDto = new UsersCollectionDto
        {
            Data = userDtos
        };

        return usersCollectionDto;
    }

    public async Task CreateForRegisterAsync(RegisterDto registerDto)
    {
        User user = mapper.Map<User>(registerDto);

        user.PasswordHash = passwordHasher.HashPassword(user, registerDto.Password);

        await userRepository.RegisterAsync(user);
    }
}
