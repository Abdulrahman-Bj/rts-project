using Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{

    public class FileServices(IWebHostEnvironment environment) : IFileServices
    {
        public void DeleteFile(string entireFileName, string destionationFolder)
        {
            if (String.IsNullOrEmpty(entireFileName))
            {
                throw new ArgumentNullException("No file exitset");
            }

            var contentPath = Path.Combine(environment.ContentRootPath, "Uploads",destionationFolder, entireFileName);

            if (!File.Exists(contentPath))
            {
                throw new ArgumentNullException("No file exitset");
            }

            File.Delete(contentPath);
        }

        public async Task<string> SaveFileAsync(IFormFile imageFile, string[] allowedFileExtensions, string destionationFolder)
        {

            if (imageFile == null)
            {
                throw new ArgumentNullException(nameof(imageFile));
            }

            var contentPath = environment.ContentRootPath;
            var path = Path.Combine(contentPath, "Uploads", $"{destionationFolder}");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var ext = Path.GetExtension(imageFile.FileName);

            if (!allowedFileExtensions.Contains(ext))
            {
                throw new ArgumentException($"Only {String.Join(",", allowedFileExtensions)} are allowed");
            }

            var fileName = $"{Guid.NewGuid().ToString()}{ext}";
            var fileNameWithPath = Path.Combine(path,fileName);
            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            await imageFile.CopyToAsync(stream);
            return fileName;

        }

        public Task<string> SaveFileAsync(IFormFile imageFile, string[] allowedFileExtensions)
        {
            throw new NotImplementedException();
        }
    }
}
