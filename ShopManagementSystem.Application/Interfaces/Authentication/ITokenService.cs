using ShopManagementSystem.Domain.Entities.Identity;

public interface ITokenService
{
    string CreateToken(User user);
}