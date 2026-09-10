using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ShopManagementSystem.Application.Interfaces.Common;

namespace ShopManagementSystem.Application.Services.Common;

public class FileService(IWebHostEnvironment environment) : IFileService
{
    public async Task<string> SaveFileAsync(IFormFile file)
    {
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

        var directory = Path.Combine(environment.WebRootPath, "images");

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
        var filePath = Path.Combine(environment.WebRootPath, "images", pictureName);

        if (File.Exists(filePath))
            File.Delete(filePath);
    }
}
