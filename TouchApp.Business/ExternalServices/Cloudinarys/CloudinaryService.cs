using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Utilities.Services.Rest;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Business.ExternalServices.Cloudinarys
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly IConfiguration _configuration;
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            _configuration = configuration;

            var account = new Account(
                _configuration["Cloudinary:CloudName"],
                _configuration["Cloudinary:ApiKey"],
                _configuration["Cloudinary:ApiSecret"]);

            _cloudinary = new Cloudinary(account);
        }


        public string StoreImage(string file)
        {
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", file);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(sourcePath),
                UniqueFilename = true,
                Folder = "mvp/uploads/",
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            return uploadResult.PublicId;
        }

        public string StoreVideo(string file)
        {
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", file);
            //var uploadParams = new ImageUploadParams()
            //{
            //    File = new FileDescription(sourcePath),
            //    UniqueFilename = true,
            //    Folder = "mvp/uploads/",
            //};

            //var uploadResult = _cloudinary.Upload(uploadParams);

            //return uploadResult.PublicId;

            var uploadParams = new VideoUploadParams()
            {
                File = new FileDescription(sourcePath),
                UniqueFilename = true,
                Overwrite = true,
                Folder = "mvp/uploads/"
                //NotificationUrl = "https://mysite/my_notification_endpoint"
            };
            var uploadResult = _cloudinary.Upload(uploadParams);
            return uploadResult.PublicId;
        }

        public string StoreResized(string file, int width, int height, string crop)
        {
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "temp", file);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(sourcePath),
                UniqueFilename = true,
                Folder = "mvp/uploads/",
                Transformation = new Transformation().Width(width).Height(height).Crop(crop)
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            return uploadResult.PublicId;
        }

        public string BuildUrl(string publicId, string crop = "fill", int width = 150, int height = 150)
        {
            return _cloudinary.Api.Url.Secure(true)
                .Transform(new Transformation().Width(width).Height(height).Crop(crop))
                .BuildUrl(publicId);
        }

        public void Delete(string publicId)
        {
            _cloudinary.DeleteResources(publicId);
        }

        public string StoreFromUrl(string url)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(url),
                UniqueFilename = true,
                Folder = "mvp/uploads/"
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            return uploadResult.PublicId;
        }

        public string BuildUrl(string publicId)
        {
            return _cloudinary.Api.Url.Secure(true).BuildUrl(publicId);
        }

        public string BuildUrlVideo(string publicId)
        {
            return _cloudinary.Api.UrlVideoUp.Secure(true).BuildUrl(publicId);
        }
    }
}
