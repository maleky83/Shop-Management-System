using ShopManagementSystem.Domain.Entities.Identity;

namespace ShopManagementSystem.Application.Interfaces.Authentication;

public interface ITokenService
{
    string CreateToken(User user);
}
