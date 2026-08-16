using ShopManagementSystem.Domain.Entities.User;

public interface ITokenService
{
    string CreateToken(User user);
}