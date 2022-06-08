using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Infrastructure.Photos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PetManager.Models;

namespace PetManager.Utilities.Photo
{
    public class AddPhoto: ControllerBase
    {
        private readonly Cloudinary _Cloudinary;
        public AddPhoto(Cloudinary Cloudinary)
        {
           _Cloudinary= Cloudinary;
        }
        public  async Task<PhotoUploadResult> FileUpload(IFormFile file)
        {
            if (file.Length > 0)
            {
                await using var stream = file.OpenReadStream();

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill")
                };

                var uploadResult = await _Cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                {
                    throw new Exception(uploadResult.Error.Message);
                }
                return new PhotoUploadResult
                {
                    PublicId = uploadResult.PublicId,
                    URL = uploadResult.SecureUrl.ToString()
                };
            }
            return null;
        }
    }
}

