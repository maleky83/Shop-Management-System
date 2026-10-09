using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using ShopManagementSystem.Application.Exceptions;
using ShopManagementSystem.Application.Interfaces.Authentication;
using ShopManagementSystem.Application.Users.Dtos;
using ShopManagementSystem.Domain.Entities.Identity;
using ShopManagementSystem.Domain.Repositories;

namespace ShopManagementSystem.Application.Users;

public sealed class AccountService(
    IPasswordHasher<User> passwordHasher,
    ITokenService tokenService,
    IMapper mapper,
    IUserRepository userRepository,
    IValidator<RegisterDto> validator
    ) : IAccountService
{
    public async Task RegisterAsync(RegisterDto dto)
    {
        await validator.ValidateAndThrowAsync(dto);

        User user = mapper.Map<User>(dto);

        user.PasswordHash = passwordHasher.HashPassword(user, dto.Password);

        await userRepository.CreateAsync(user);
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
    {
        User user = await userRepository.GetUserByNameAsync(dto.Name);

        if (user == null)
            throw new NotFoundException("Invalid username or password.");

        PasswordVerificationResult passwordResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

        if (passwordResult == PasswordVerificationResult.Failed)
            throw new NotFoundException("Invalid username or password.");

        var token = tokenService.CreateToken(user);

        return new LoginResponseDto()
        {
            Token = token
        };
    }
}
