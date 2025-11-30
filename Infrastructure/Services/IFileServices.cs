using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IFileServices
    {
        Task<string> SaveFileAsync(IFormFile imageFile, string[] allowedFileExtensions, string destionationFolder);
        void DeleteFile(string entireFileName, string destionationFolder);
    }
}
