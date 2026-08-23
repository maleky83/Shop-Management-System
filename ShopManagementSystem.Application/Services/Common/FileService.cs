using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ShopManagementSystem.Application.Interfaces.Common;

namespace ShopManagementSystem.Application.Services.Common
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;
        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            var directory = Path.Combine(_environment.WebRootPath, "images");

            if (Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var filePath = Path.Combine(directory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public void DeleleFile(string pictureName)
        {
            var filePath = Path.Combine(_environment.WebRootPath, "images", pictureName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
