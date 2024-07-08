using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Infrastucture.Repository.Implementation
{
    public class FileRepository : IFileRepository
    {
        private readonly IConfiguration _configuration;
        private readonly Account _account;
        public FileRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _account = new Account(
            _configuration.GetSection("Cloudinary")["CloudName"],
            _configuration.GetSection("Cloudinary")["ApiKey"],
            _configuration.GetSection("Cloudinary")["ApiSecret"]);
        }

        public async Task<string> UploadFileAsync(IFormFile formFile)
        {
            var client = new Cloudinary(_account);
            if (formFile.ContentType.StartsWith("video/"))
            {

                var uploadParams = new VideoUploadParams()
                {
                    File = new FileDescription(formFile.FileName, formFile.OpenReadStream()),
                    DisplayName = formFile.FileName
                };
                var uploadResult = await client.UploadAsync(uploadParams);

                if (uploadResult != null && uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return uploadResult.SecureUri.ToString();
                }
            }
            else if (formFile.ContentType.StartsWith("image/"))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(formFile.FileName, formFile.OpenReadStream()),
                    PublicId = Path.GetFileNameWithoutExtension(formFile.FileName),
                    DisplayName = formFile.FileName
                };
                var uploadResult = await client.UploadAsync(uploadParams);

                if (uploadResult != null && uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return uploadResult.SecureUri.ToString();
                }
            }
            else if (formFile.ContentType == "text/plain" || formFile.ContentType == "application/pdf")
            {
                var uploadParams = new RawUploadParams()
                {
                    File = new FileDescription(formFile.FileName, formFile.OpenReadStream()),
                    PublicId = Path.GetFileNameWithoutExtension(formFile.FileName),
                    DisplayName = formFile.FileName
                };
                var uploadResult = await client.UploadAsync(uploadParams);

                if (uploadResult != null && uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return uploadResult.SecureUri.ToString();
                }
            }
            return null;
        }


    }
}