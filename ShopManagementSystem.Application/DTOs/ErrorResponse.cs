namespace ShopManagementSystem.Application.DTOs
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public required string Message { get; set; }
    }
}