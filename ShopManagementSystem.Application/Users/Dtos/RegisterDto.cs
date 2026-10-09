namespace ShopManagementSystem.Application.Users.Dtos;

public class RegisterDto
{
    //[Remote("VerifyName", "Account")]
    public string Name { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string RePassword { get; set; } = default!;
}
