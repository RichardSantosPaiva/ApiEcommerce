using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ApiEcommerce.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            string fileName = GenerateNewFileName(file.FileName);
            string directory = CreateFilePath(fileName);

            byte[] bytesFile = ConvertFileInByteArray(file);
            await System.IO.File.WriteAllBytesAsync(directory, bytesFile);

            var url = GetFileUrl(fileName);
            return url;
        }

        private string GetFileFormat(string fullFileName)
        {
            var format = fullFileName.Split(".").Last();
            return "." + format;
        }

        private string GenerateNewFileName(string fileName)
        {
            var newFileName = (Guid.NewGuid().ToString() + "_" + fileName).ToLower();
            newFileName = newFileName.Replace("-", "");

            return newFileName;
        }

        private string CreateFilePath(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
        }

        private string GetFileUrl(string fileName)
        {
            var baseUrl = _configuration["Directories:BaseUrl"];
            var fileUrl = "images/" + fileName;
            return (baseUrl + "/" + fileUrl);
        }

        private byte[] ConvertFileInByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
