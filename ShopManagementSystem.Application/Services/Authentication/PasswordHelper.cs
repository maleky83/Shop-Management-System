using Microsoft.AspNetCore.Identity;

namespace ShopManagementSystem.Application.Services.Authentication;

public static class PasswordHelper
{
    private static readonly PasswordHasher<object> passwordHasher = new();

    public static string HashPassword(string password)
    {
        return passwordHasher.HashPassword(null!, password);
    }

    public static bool VerifyPassword(string hashedPassword, string password)
    {
        PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(null!, hashedPassword, password);

        return result == PasswordVerificationResult.Success ||
               result == PasswordVerificationResult.SuccessRehashNeeded;
    }
}
