
using Microsoft.AspNetCore.Http;

namespace ShopManagementSystem.Core.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(int fileId, IFormFile file);
        void DeleleFile(int fileId, string pictureName);
    } 
}
