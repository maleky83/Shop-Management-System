using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ShopManagementSystem.Core.Services.Interfaces;
using ShopManagementSystem.Data.Context;

namespace ShopManagementSystem.Core.Services
{
    public class FileService : IFileService
    {
        private readonly ProgramContext _context;
        private readonly IWebHostEnvironment _environment;
        public FileService(ProgramContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<string> SaveFileAsync(int fileId, IFormFile file)
        {
            string fileName = fileId + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    _environment.WebRootPath,
                    "images",
                    fileName
                    );

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public void DeleleFile(int fileId, string pictureName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _environment.WebRootPath, "images", fileId +
                Path.GetExtension(pictureName)
                );

            if (File.Exists(filePath))
                File.Delete(filePath);


        }
    }
}
