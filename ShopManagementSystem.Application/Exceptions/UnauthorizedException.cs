namespace ShopManagementSystem.Application.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string name) : base(name) { }
    }
}
