using Microsoft.AspNetCore.Http;
using Service.Helper.Responses;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class FileService : IFileService
    {

        public void DeleteAsync(string path)
        {
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            var fileFullPath = Path.Combine(uploadFolder, path);

            if (File.Exists(fileFullPath))
            {
                File.Delete(fileFullPath);
            }
        }

        public async Task<UploadResponse> UploadAsync(IFormFile file)
        {
            List<string> validExtentions = new List<string>() { ".jpg", ".png", ".gif" };

            string fileExtention = Path.GetExtension(file.FileName);

            if (!validExtentions.Contains(fileExtention))
            {
                return new UploadResponse { HasError = true, Response = $"File extention is wrong,must be ({string.Join(",", validExtentions)})" };
            }

            long size = file.Length;

            if (size > 2 * 1024 * 1024)
            {
                return new UploadResponse { HasError = true, Response = "File size can be max 2 mb" };
            }

            string fileName = Guid.NewGuid().ToString() + fileExtention;

            if (!Directory.Exists("Uploads"))
            {
                Directory.CreateDirectory("Uploads");
            }

            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

            using FileStream stream = new(path, FileMode.Create);

            await file.CopyToAsync(stream);

            return new UploadResponse { HasError = false, Response = fileName };

        }
    }
}
