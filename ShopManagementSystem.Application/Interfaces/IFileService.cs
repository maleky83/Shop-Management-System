
using Microsoft.AspNetCore.Http;

namespace ShopManagementSystem.Application.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file);
        void DeleleFile(string pictureName);
    }
}
