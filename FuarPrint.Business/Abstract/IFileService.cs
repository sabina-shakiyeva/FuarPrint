using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuarPrint.Business.Abstract
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file);
        string GetFileUrl(string filePath);
    }
}
