using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Domain.RepositoryInterfaces
{
    public interface IFileRepository
    {
        Task<string> UploadFileAsync(IFormFile formfile);
    }
}