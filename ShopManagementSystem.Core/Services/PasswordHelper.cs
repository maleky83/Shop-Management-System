using Microsoft.AspNetCore.Identity;

namespace ShopManagementSystem.Core.Services
{
    public static class PasswordHelper
    {
        private static readonly PasswordHasher<object> _passwordHasher = new();

        public static string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null!, password);
        }

        public static bool VerifyPassword(string hashedPassword, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(null!, hashedPassword, password);

            return result == PasswordVerificationResult.Success ||
                   result == PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}